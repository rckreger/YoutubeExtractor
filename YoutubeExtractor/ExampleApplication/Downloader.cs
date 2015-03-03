using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;


using YoutubeExtractor;

namespace ExampleApplication
{
   
   public partial class Downloader : Form
   {
      private double mPercentComplete = 0;
      private BindingSource mBindingSource = new BindingSource();
      List<Downloads> mDownloadsArray = new List<Downloads>();
      bool mExitEvent = false;

      Thread mThread = null;

     private  log4net.ILog mLogger = log4net.LogManager.GetLogger("Downloader");


      public Downloader()
      {
         InitializeComponent();

         mThread = new Thread(new ThreadStart(this.svc));
         mThread.Start();

         textBoxFile.Text = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

         mLogger.Info("Default folder = " + textBoxFile.Text);


         radioButton1080p.Checked = false;
         radioButton720p.Checked = false;
         radioButton360p.Checked = false;
         labelFilename.Text = "";

         mBindingSource.DataSource = mDownloadsArray;
         this.dataGridView.DataSource = mBindingSource;
         this.dataGridView.MultiSelect = false;
         this.dataGridView.RowHeadersVisible = false;
         this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

         DataGridViewColumn column = dataGridView.Columns[0];
         column.Width = 100;
         column = dataGridView.Columns[1];
         column.Width = 300;
         column = dataGridView.Columns[2];
         column.Width = 100;

      }

      public void DownloadChanged(double aPercentComplete, int aSizeDownloaded)
      {
         mPercentComplete = aPercentComplete;

         lock (mDownloadsArray)
         {
            if (mDownloadsArray.Count > 0)
            {
               mDownloadsArray[0].PercentComplete = (int)aPercentComplete;
               mDownloadsArray[0].Length = aSizeDownloaded.ToString();
            }
         }
      }

      private void buttonDownload_Click(object sender, EventArgs e)
      {
         mLogger.Info("buttonDownload_Click");

         timerFormUpdate.Interval = 500;
         timerFormUpdate.Enabled = true;
         int lResolution = 1080;
         if(radioButton1080p.Checked) lResolution = 1080;
         if(radioButton720p.Checked) lResolution = 720;
         if(radioButton360p.Checked)  lResolution = 360;

         DownloadVideo(textBoxURL.Text, lResolution);
      }

      private void textBoxURL_TextChanged(object sender, EventArgs e)
      {
         mLogger.Info("textBoxURL_TextChanged");
         mPercentComplete = 0;
         try
         {
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(textBoxURL.Text, false);
            VideoInfo lVideo = null;
            try
            {
               lVideo = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 1080);
               if(lVideo != null)
               {
                  mLogger.Info("textBoxURL_TextChanged - video format 1080");
                  radioButton1080p.Checked = true;
                  radioButton720p.Checked = false;
                  radioButton360p.Checked = false;
                  labelFilename.Text = lVideo.Title;
                  return;
               }
            }
            catch (Exception aEx)
            {
               System.Diagnostics.Debug.Assert(false);
               mLogger.Error("textBoxURL_TextChanged - Exception " + aEx.Message);

            }

            try
            {
               lVideo = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 720);
               if (lVideo != null)
               {
                  mLogger.Info("textBoxURL_TextChanged - video format 720");
                  radioButton1080p.Checked = false;
                  radioButton720p.Checked = true;
                  radioButton360p.Checked = false;
                  labelFilename.Text = lVideo.Title;

                  return;
               }
            }
            catch (Exception aEx)
            {
               System.Diagnostics.Debug.Assert(false);
               mLogger.Error("textBoxURL_TextChanged - Exception " + aEx.Message);

            }

            try
            {
               lVideo = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == 360);
               if (lVideo != null)
               {
                  mLogger.Info("textBoxURL_TextChanged - video format 360");
                  radioButton1080p.Checked = false;
                  radioButton720p.Checked = false;
                  radioButton360p.Checked = true;
                  labelFilename.Text = lVideo.Title;

                  return;
               }
            }
            catch (Exception aEx)
            {
               System.Diagnostics.Debug.Assert(false);
               mLogger.Error("textBoxURL_TextChanged - Exception " + aEx.Message);
            }

         }
         catch (Exception aEx)
         {
            System.Diagnostics.Debug.Assert(false);
            mLogger.Error("textBoxURL_TextChanged - Exception " + aEx.Message);
         }
      }

      public void DownloadAudio(IEnumerable<VideoInfo> videoInfos)
      {
         mLogger.Info("DownloadAudio");
         /*
          * We want the first extractable video with the highest audio quality.
          */
         VideoInfo video = videoInfos
             .Where(info => info.CanExtractAudio)
             .OrderByDescending(info => info.AudioBitrate)
             .First();

         /*
          * If the video has a decrypted signature, decipher it
          */
         if (video.RequiresDecryption)
         {
            DownloadUrlResolver.DecryptDownloadUrl(video);
         }

         /*
          * Create the audio download.
          * The first argument is the video where the audio should be extracted from.
          * The second argument is the path to save the audio file.
          */

         var audioDownloader = new AudioDownloader(video,
             Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
             RemoveIllegalPathCharacters(video.Title) + video.AudioExtension));

         // Register the progress events. We treat the download progress as 85% of the progress
         // and the extraction progress only as 15% of the progress, because the download will
         // take much longer than the audio extraction.
         //audioDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage * 0.85);
         audioDownloader.DownloadProgressChanged += (sender, args) => DownloadChanged(args.ProgressPercentage * 0.85, 0);
         
         //audioDownloader.AudioExtractionProgressChanged += (sender, args) => Console.WriteLine(85 + args.ProgressPercentage * 0.15);

         /*
          * Execute the audio download.
          * For GUI applications note, that this method runs synchronously.
          */
         audioDownloader.Execute();
         audioDownloader.DownloadProgressChanged += (sender, args) => DownloadChanged(100, -1);
      }

      public void DownloadVideo(IEnumerable<VideoInfo> videoInfos, int aResolution)
      {
         mLogger.Info("DownloadVideo");
         /*
          * Select the first .mp4 video with 360p resolution
          */
         VideoInfo video = videoInfos.First(info => info.VideoType == VideoType.Mp4 && info.Resolution == aResolution);

         /*
          * If the video has a decrypted signature, decipher it
          */
         if (video.RequiresDecryption)
         {
            mLogger.Info("DownloadVideo - video.RequiresDecryption is true");
            DownloadUrlResolver.DecryptDownloadUrl(video);
         }

         /*
          * Create the video downloader.
          * The first argument is the video to download.
          * The second argument is the path to save the video file.
          */
         var videoDownloader = new VideoDownloader(video,
             Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
             RemoveIllegalPathCharacters(video.Title) + video.VideoExtension));

         // Register the ProgressChanged event and print the current progress
         //videoDownloader.DownloadProgressChanged += (sender, args) => Console.WriteLine(args.ProgressPercentage);
         videoDownloader.DownloadProgressChanged += (sender, args) => DownloadChanged(args.ProgressPercentage * 0.85, args.Size);
        

         /*
          * Execute the video downloader.
          * For GUI applications note, that this method runs synchronously.
          */
         mLogger.Info("DownloadVideo - Execute is next");
         videoDownloader.Execute();

         videoDownloader.DownloadProgressChanged += (sender, args) => DownloadChanged(100, args.Size);
      }

      string RemoveIllegalPathCharacters(string aPath)
      {
         string regexSearch = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
         var r = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));
         string lTemp = r.Replace(aPath, "");

         mLogger.Info("RemoveIllegalPathCharacters.  Old Name" + aPath + ", new path " + lTemp);

         return lTemp;
      }

      private void timerFormUpdate_Tick(object sender, EventArgs e)
      {
         labelPercentComplete.Text = this.mPercentComplete.ToString();

         lock (mDownloadsArray)
         {
            //Update the data grid from binding source
            mBindingSource.ResetBindings(false);
         }

      }

      private void button2_Click(object sender, EventArgs e)
      {
         mLogger.Info("button2_Click");
         
         timerFormUpdate.Interval = 500;
         timerFormUpdate.Enabled = true;

         Downloads lDownload = new Downloads(textBoxURL.Text);
         lDownload.Filename = labelFilename.Text;

         if (radioButton1080p.Checked == true)
         {
            lDownload.Resolution = "1080p";
            lDownload.ResolutionInt = 1080;
         }
         else if (radioButton720p.Checked == true)
         {
            lDownload.Resolution = "720p";
            lDownload.ResolutionInt = 720;
         }
         else 
         {
            lDownload.Resolution = "360p";
            lDownload.ResolutionInt = 360;
         }

         lock (mDownloadsArray)
         {
            this.mDownloadsArray.Add(lDownload);
            //Update the data grid from binding source
            mBindingSource.ResetBindings(false);
         }
      }

      private void svc()
      {
         mLogger.Info("Thread started");
         while (mExitEvent == false)
         {
            try
            {
               bool lSleep = false;
               Downloads lDownload = null;
               lock (mDownloadsArray)
               {

                  if (mDownloadsArray.Count == 0)
                  {
                     lSleep = true;
                  }
                  else
                  {
                  
                     //Get the video information from the download array
                     lDownload = mDownloadsArray[0];
                  }
               }
               if(lSleep)
               {
                  Thread.Sleep(100);
                  continue;
               }

               try
               {
                  DownloadVideo(lDownload.URL, lDownload.ResolutionInt);
               }
               catch (Exception aEx)
               {
                  mLogger.Error("Exception in svc.  Exception = " + aEx.Message);
               }


               lock (mDownloadsArray)
               {
                  mDownloadsArray.RemoveAt(0);
               }
           }
            catch (Exception aEx)
            {
               mLogger.Error("Exception in svc.  Exception = " + aEx.Message);

            }
      }
      }

      private void Downloader_Load(object sender, EventArgs e)
      {

      }

      private void Downloader_FormClosing(object sender, FormClosingEventArgs e)
      {
         mLogger.Info("Downloader_FormClosing");

         mExitEvent = true;
         while (this.mThread.IsAlive)
         {
            Thread.Sleep(100);
         }
      }

      private void DownloadVideo(string aURL, int aResolution)
      {
         mLogger.Info("DownloadVideo.  URL=" + aURL + " " + aResolution + "p");

         try
         {
            IEnumerable<VideoInfo> videoInfos = DownloadUrlResolver.GetDownloadUrls(aURL, false);
            DownloadVideo(videoInfos, aResolution);
         }
         catch (Exception aEx)
         {
            mLogger.Error("DownloadVideo.  URL=" + aURL + " " + aResolution + "p. Exception: " + aEx.Message);
         }
      }
   }
}
