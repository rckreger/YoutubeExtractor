using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using YoutubeExtractor;

// Import log4net classes.
//using log4net;
//using log4net.Config;

namespace ExampleApplication
{
    internal class Program
    {
       private static void Main(string[] args)
        {
           try
           {
              // BasicConfigurator replaced with XmlConfigurator.
              log4net.Config.XmlConfigurator.Configure();

              Downloader lDownloader = new Downloader();
              lDownloader.ShowDialog();
           }
           catch (Exception)
           {

           }

           //TODO:  Add command line code here.
        }

    }
}