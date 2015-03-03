namespace ExampleApplication
{
   partial class Downloader
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.textBoxURL = new System.Windows.Forms.TextBox();
         this.textBoxFile = new System.Windows.Forms.TextBox();
         this.button1 = new System.Windows.Forms.Button();
         this.groupBoxVideoSizes = new System.Windows.Forms.GroupBox();
         this.labelPercentComplete = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.labelFilename = new System.Windows.Forms.Label();
         this.lableFilename = new System.Windows.Forms.Label();
         this.radioButton360p = new System.Windows.Forms.RadioButton();
         this.radioButton720p = new System.Windows.Forms.RadioButton();
         this.radioButton1080p = new System.Windows.Forms.RadioButton();
         this.timerFormUpdate = new System.Windows.Forms.Timer(this.components);
         this.dataGridView = new System.Windows.Forms.DataGridView();
         this.button2 = new System.Windows.Forms.Button();
         this.groupBoxVideoSizes.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(13, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(29, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "URL";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(13, 75);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(113, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Folder Path to Save to";
         // 
         // textBoxURL
         // 
         this.textBoxURL.Location = new System.Drawing.Point(13, 28);
         this.textBoxURL.Name = "textBoxURL";
         this.textBoxURL.Size = new System.Drawing.Size(669, 20);
         this.textBoxURL.TabIndex = 2;
         this.textBoxURL.TextChanged += new System.EventHandler(this.textBoxURL_TextChanged);
         // 
         // textBoxFile
         // 
         this.textBoxFile.Location = new System.Drawing.Point(13, 91);
         this.textBoxFile.Name = "textBoxFile";
         this.textBoxFile.Size = new System.Drawing.Size(669, 20);
         this.textBoxFile.TabIndex = 3;
         this.textBoxFile.Text = "c:\\temp";
         // 
         // button1
         // 
         this.button1.Location = new System.Drawing.Point(16, 268);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(75, 23);
         this.button1.TabIndex = 4;
         this.button1.Text = "Download";
         this.button1.UseVisualStyleBackColor = true;
         this.button1.Click += new System.EventHandler(this.buttonDownload_Click);
         // 
         // groupBoxVideoSizes
         // 
         this.groupBoxVideoSizes.Controls.Add(this.labelPercentComplete);
         this.groupBoxVideoSizes.Controls.Add(this.label3);
         this.groupBoxVideoSizes.Controls.Add(this.labelFilename);
         this.groupBoxVideoSizes.Controls.Add(this.lableFilename);
         this.groupBoxVideoSizes.Controls.Add(this.radioButton360p);
         this.groupBoxVideoSizes.Controls.Add(this.radioButton720p);
         this.groupBoxVideoSizes.Controls.Add(this.radioButton1080p);
         this.groupBoxVideoSizes.Location = new System.Drawing.Point(16, 124);
         this.groupBoxVideoSizes.Name = "groupBoxVideoSizes";
         this.groupBoxVideoSizes.Size = new System.Drawing.Size(666, 124);
         this.groupBoxVideoSizes.TabIndex = 5;
         this.groupBoxVideoSizes.TabStop = false;
         this.groupBoxVideoSizes.Text = "Video Format";
         // 
         // labelPercentComplete
         // 
         this.labelPercentComplete.AutoSize = true;
         this.labelPercentComplete.Location = new System.Drawing.Point(193, 42);
         this.labelPercentComplete.Name = "labelPercentComplete";
         this.labelPercentComplete.Size = new System.Drawing.Size(13, 13);
         this.labelPercentComplete.TabIndex = 6;
         this.labelPercentComplete.Text = "0";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(90, 43);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(91, 13);
         this.label3.TabIndex = 5;
         this.label3.Text = "Percent Complete";
         // 
         // labelFilename
         // 
         this.labelFilename.AutoSize = true;
         this.labelFilename.Location = new System.Drawing.Point(190, 20);
         this.labelFilename.Name = "labelFilename";
         this.labelFilename.Size = new System.Drawing.Size(35, 13);
         this.labelFilename.TabIndex = 4;
         this.labelFilename.Text = "label3";
         // 
         // lableFilename
         // 
         this.lableFilename.AutoSize = true;
         this.lableFilename.Location = new System.Drawing.Point(87, 20);
         this.lableFilename.Name = "lableFilename";
         this.lableFilename.Size = new System.Drawing.Size(49, 13);
         this.lableFilename.TabIndex = 3;
         this.lableFilename.Text = "Filename";
         // 
         // radioButton360p
         // 
         this.radioButton360p.AutoSize = true;
         this.radioButton360p.Location = new System.Drawing.Point(25, 67);
         this.radioButton360p.Name = "radioButton360p";
         this.radioButton360p.Size = new System.Drawing.Size(49, 17);
         this.radioButton360p.TabIndex = 2;
         this.radioButton360p.TabStop = true;
         this.radioButton360p.Text = "360p";
         this.radioButton360p.UseVisualStyleBackColor = true;
         // 
         // radioButton720p
         // 
         this.radioButton720p.AutoSize = true;
         this.radioButton720p.Location = new System.Drawing.Point(25, 43);
         this.radioButton720p.Name = "radioButton720p";
         this.radioButton720p.Size = new System.Drawing.Size(49, 17);
         this.radioButton720p.TabIndex = 1;
         this.radioButton720p.TabStop = true;
         this.radioButton720p.Text = "720p";
         this.radioButton720p.UseVisualStyleBackColor = true;
         // 
         // radioButton1080p
         // 
         this.radioButton1080p.AutoSize = true;
         this.radioButton1080p.Location = new System.Drawing.Point(25, 19);
         this.radioButton1080p.Name = "radioButton1080p";
         this.radioButton1080p.Size = new System.Drawing.Size(55, 17);
         this.radioButton1080p.TabIndex = 0;
         this.radioButton1080p.TabStop = true;
         this.radioButton1080p.Text = "1080p";
         this.radioButton1080p.UseVisualStyleBackColor = true;
         // 
         // timerFormUpdate
         // 
         this.timerFormUpdate.Enabled = true;
         this.timerFormUpdate.Interval = 1000;
         this.timerFormUpdate.Tick += new System.EventHandler(this.timerFormUpdate_Tick);
         // 
         // dataGridView
         // 
         this.dataGridView.AllowUserToAddRows = false;
         this.dataGridView.AllowUserToOrderColumns = true;
         this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView.Location = new System.Drawing.Point(16, 297);
         this.dataGridView.MultiSelect = false;
         this.dataGridView.Name = "dataGridView";
         this.dataGridView.Size = new System.Drawing.Size(661, 161);
         this.dataGridView.TabIndex = 6;
         // 
         // button2
         // 
         this.button2.Location = new System.Drawing.Point(106, 268);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(116, 23);
         this.button2.TabIndex = 7;
         this.button2.Text = "Queue Download";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // Downloader
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(703, 470);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.dataGridView);
         this.Controls.Add(this.groupBoxVideoSizes);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.textBoxFile);
         this.Controls.Add(this.textBoxURL);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Name = "Downloader";
         this.Text = "Downloader";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Downloader_FormClosing);
         this.Load += new System.EventHandler(this.Downloader_Load);
         this.groupBoxVideoSizes.ResumeLayout(false);
         this.groupBoxVideoSizes.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.TextBox textBoxURL;
      private System.Windows.Forms.TextBox textBoxFile;
      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.GroupBox groupBoxVideoSizes;
      private System.Windows.Forms.Label labelFilename;
      private System.Windows.Forms.Label lableFilename;
      private System.Windows.Forms.RadioButton radioButton360p;
      private System.Windows.Forms.RadioButton radioButton720p;
      private System.Windows.Forms.RadioButton radioButton1080p;
      private System.Windows.Forms.Timer timerFormUpdate;
      private System.Windows.Forms.Label labelPercentComplete;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.DataGridView dataGridView;
      private System.Windows.Forms.Button button2;
   }
}