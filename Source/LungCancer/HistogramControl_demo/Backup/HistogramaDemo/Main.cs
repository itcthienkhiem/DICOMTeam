using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace HistogramDemo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnLoadHistogram;
		private System.Windows.Forms.PictureBox pbImage;
		private System.Windows.Forms.StatusBar sbInfo;
		private Histograma.HistogramaDesenat Histogram;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnLoadHistogram = new System.Windows.Forms.Button();
			this.pbImage = new System.Windows.Forms.PictureBox();
			this.sbInfo = new System.Windows.Forms.StatusBar();
			this.Histogram = new Histograma.HistogramaDesenat();
			this.SuspendLayout();
			// 
			// txtFileName
			// 
			this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileName.Location = new System.Drawing.Point(64, 8);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(928, 21);
			this.txtFileName.TabIndex = 7;
			this.txtFileName.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(38, 17);
			this.label2.TabIndex = 6;
			this.label2.Text = "Picture";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBrowse.Location = new System.Drawing.Point(1000, 8);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(24, 23);
			this.btnBrowse.TabIndex = 5;
			this.btnBrowse.Text = "...";
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnLoadHistogram
			// 
			this.btnLoadHistogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.btnLoadHistogram.Location = new System.Drawing.Point(16, 40);
			this.btnLoadHistogram.Name = "btnLoadHistogram";
			this.btnLoadHistogram.Size = new System.Drawing.Size(1008, 23);
			this.btnLoadHistogram.TabIndex = 4;
			this.btnLoadHistogram.Text = "Compute histogram for image";
			this.btnLoadHistogram.Click += new System.EventHandler(this.btnLoadHistogram_Click);
			// 
			// pbImage
			// 
			this.pbImage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pbImage.Location = new System.Drawing.Point(16, 72);
			this.pbImage.Name = "pbImage";
			this.pbImage.Size = new System.Drawing.Size(368, 424);
			this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbImage.TabIndex = 10;
			this.pbImage.TabStop = false;
			// 
			// sbInfo
			// 
			this.sbInfo.Location = new System.Drawing.Point(0, 504);
			this.sbInfo.Name = "sbInfo";
			this.sbInfo.Size = new System.Drawing.Size(1032, 22);
			this.sbInfo.TabIndex = 11;
			this.sbInfo.Text = "statusBar1";
			// 
			// Histogram
			// 
			this.Histogram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.Histogram.DisplayColor = System.Drawing.Color.Black;
			this.Histogram.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Histogram.Location = new System.Drawing.Point(392, 72);
			this.Histogram.Name = "Histogram";
			this.Histogram.Offset = 20;
			this.Histogram.Size = new System.Drawing.Size(632, 424);
			this.Histogram.TabIndex = 12;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(1032, 526);
			this.Controls.Add(this.Histogram);
			this.Controls.Add(this.sbInfo);
			this.Controls.Add(this.pbImage);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.btnLoadHistogram);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "MainForm";
			this.Text = "Image color histogram";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btnBrowse_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();

			ofd.CheckFileExists = true;
			ofd.CheckPathExists = true;

			ofd.ShowDialog();

			if (ofd.FileName!="")
				txtFileName.Text = ofd.FileName;		
		}

		private void btnLoadHistogram_Click(object sender, System.EventArgs e)
		{
			if (txtFileName.Text != "" && System.IO.File.Exists(txtFileName.Text))
			{	
				sbInfo.Text = "Loading image";
				if (pbImage.Image!=null)
					pbImage.Image.Dispose();

				pbImage.Image = Image.FromFile(txtFileName.Text);

				Application.DoEvents();

				sbInfo.Text =  "Computing histogram";
				long[] myValues = GetHistogram(new Bitmap(pbImage.Image));

				Histogram.DrawHistogram(myValues);

				sbInfo.Text = "";
			}		
		}

		public long[] GetHistogram(System.Drawing.Bitmap picture)
		{
			long[] myHistogram = new long[256];

			for (int i=0;i<picture.Size.Width;i++)
				for (int j=0;j<picture.Size.Height;j++)
				{
					System.Drawing.Color c  = picture.GetPixel(i,j);

					long Temp=0;
					Temp+=c.R;
					Temp+=c.G;
					Temp+=c.B;

					Temp = (int) Temp/3;
					myHistogram[Temp]++;
				}

			return myHistogram;
		}

		private void Histogram_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
