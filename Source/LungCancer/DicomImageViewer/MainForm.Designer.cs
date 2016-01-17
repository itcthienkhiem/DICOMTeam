namespace DicomImageViewer
{
    partial class MainForm
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
            this.bnOpen = new System.Windows.Forms.Button();
            this.bnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bnTags = new System.Windows.Forms.Button();
            this.bnResetWL = new System.Windows.Forms.Button();
            this.gbViewSettings = new System.Windows.Forms.GroupBox();
            this.rbZoomfit = new System.Windows.Forms.RadioButton();
            this.rbZoom1_1 = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OtsuThreshold = new System.Windows.Forms.Button();
            this.pcOstu = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PC_Eff = new System.Windows.Forms.PictureBox();
            this.pcDenose = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.imagePanelControl = new DicomImageViewer.ImagePanelControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.pcBoNen = new System.Windows.Forms.PictureBox();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.denoiseFromStep3 = new System.Windows.Forms.PictureBox();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.blobsBrowser1 = new DicomImageViewer.BlobsBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.windowLevelControl = new DicomImageViewer.WindowLevelGraphControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.pc_class = new System.Windows.Forms.PictureBox();
            this.gbViewSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOstu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Eff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDenose)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBoNen)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.denoiseFromStep3)).BeginInit();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pc_class)).BeginInit();
            this.SuspendLayout();
            // 
            // bnOpen
            // 
            this.bnOpen.Location = new System.Drawing.Point(35, 12);
            this.bnOpen.Name = "bnOpen";
            this.bnOpen.Size = new System.Drawing.Size(117, 28);
            this.bnOpen.TabIndex = 0;
            this.bnOpen.Text = "Open DICOM Image";
            this.bnOpen.UseVisualStyleBackColor = true;
            this.bnOpen.Click += new System.EventHandler(this.bnOpen_Click);
            // 
            // bnSave
            // 
            this.bnSave.Location = new System.Drawing.Point(35, 74);
            this.bnSave.Name = "bnSave";
            this.bnSave.Size = new System.Drawing.Size(117, 28);
            this.bnSave.TabIndex = 2;
            this.bnSave.Text = "Save as PNG";
            this.bnSave.UseVisualStyleBackColor = true;
            this.bnSave.Click += new System.EventHandler(this.bnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Image Size:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "label2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image Bit Depth:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "label4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bnTags
            // 
            this.bnTags.Location = new System.Drawing.Point(35, 43);
            this.bnTags.Name = "bnTags";
            this.bnTags.Size = new System.Drawing.Size(117, 28);
            this.bnTags.TabIndex = 1;
            this.bnTags.Text = "View DICOM Tags";
            this.bnTags.UseVisualStyleBackColor = true;
            this.bnTags.Click += new System.EventHandler(this.bnTags_Click);
            // 
            // bnResetWL
            // 
            this.bnResetWL.Location = new System.Drawing.Point(35, 105);
            this.bnResetWL.Name = "bnResetWL";
            this.bnResetWL.Size = new System.Drawing.Size(117, 28);
            this.bnResetWL.TabIndex = 3;
            this.bnResetWL.Text = "Reset Window/Level";
            this.bnResetWL.UseVisualStyleBackColor = true;
            this.bnResetWL.Click += new System.EventHandler(this.bnResetWL_Click);
            // 
            // gbViewSettings
            // 
            this.gbViewSettings.Controls.Add(this.rbZoomfit);
            this.gbViewSettings.Controls.Add(this.rbZoom1_1);
            this.gbViewSettings.Location = new System.Drawing.Point(12, 143);
            this.gbViewSettings.Name = "gbViewSettings";
            this.gbViewSettings.Size = new System.Drawing.Size(145, 63);
            this.gbViewSettings.TabIndex = 5;
            this.gbViewSettings.TabStop = false;
            this.gbViewSettings.Text = "View Settings";
            // 
            // rbZoomfit
            // 
            this.rbZoomfit.AutoSize = true;
            this.rbZoomfit.Checked = true;
            this.rbZoomfit.Location = new System.Drawing.Point(16, 37);
            this.rbZoomfit.Name = "rbZoomfit";
            this.rbZoomfit.Size = new System.Drawing.Size(78, 17);
            this.rbZoomfit.TabIndex = 1;
            this.rbZoomfit.TabStop = true;
            this.rbZoomfit.Text = "Zoom to Fit";
            this.rbZoomfit.UseVisualStyleBackColor = true;
            this.rbZoomfit.CheckedChanged += new System.EventHandler(this.viewSettingsCheckedChanged);
            // 
            // rbZoom1_1
            // 
            this.rbZoom1_1.AutoSize = true;
            this.rbZoom1_1.Location = new System.Drawing.Point(16, 17);
            this.rbZoom1_1.Name = "rbZoom1_1";
            this.rbZoom1_1.Size = new System.Drawing.Size(40, 17);
            this.rbZoom1_1.TabIndex = 0;
            this.rbZoom1_1.Text = "1:1";
            this.rbZoom1_1.UseVisualStyleBackColor = true;
            this.rbZoom1_1.CheckedChanged += new System.EventHandler(this.viewSettingsCheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(656, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(419, 354);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // OtsuThreshold
            // 
            this.OtsuThreshold.Location = new System.Drawing.Point(28, 541);
            this.OtsuThreshold.Name = "OtsuThreshold";
            this.OtsuThreshold.Size = new System.Drawing.Size(75, 23);
            this.OtsuThreshold.TabIndex = 15;
            this.OtsuThreshold.Text = "OtsuThreshold";
            this.OtsuThreshold.UseVisualStyleBackColor = true;
            this.OtsuThreshold.Click += new System.EventHandler(this.button1_Click);
            // 
            // pcOstu
            // 
            this.pcOstu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcOstu.Location = new System.Drawing.Point(3, 3);
            this.pcOstu.Name = "pcOstu";
            this.pcOstu.Size = new System.Drawing.Size(1036, 713);
            this.pcOstu.TabIndex = 16;
            this.pcOstu.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 576);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Otsu Threshold Value";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(11, 592);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(141, 20);
            this.textBox3.TabIndex = 17;
            // 
            // PC_Eff
            // 
            this.PC_Eff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PC_Eff.Location = new System.Drawing.Point(3, 3);
            this.PC_Eff.Name = "PC_Eff";
            this.PC_Eff.Size = new System.Drawing.Size(1036, 713);
            this.PC_Eff.TabIndex = 19;
            this.PC_Eff.TabStop = false;
            // 
            // pcDenose
            // 
            this.pcDenose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcDenose.Location = new System.Drawing.Point(3, 3);
            this.pcDenose.Name = "pcDenose";
            this.pcDenose.Size = new System.Drawing.Size(1036, 713);
            this.pcDenose.TabIndex = 21;
            this.pcDenose.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Controls.Add(this.tabPage8);
            this.tabControl1.Location = new System.Drawing.Point(202, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1050, 745);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.imagePanelControl);
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1042, 719);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Step 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // imagePanelControl
            // 
            this.imagePanelControl.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.imagePanelControl.BackColor = System.Drawing.SystemColors.Control;
            this.imagePanelControl.CausesValidation = false;
            this.imagePanelControl.Location = new System.Drawing.Point(6, 6);
            this.imagePanelControl.Name = "imagePanelControl";
            this.imagePanelControl.Size = new System.Drawing.Size(644, 707);
            this.imagePanelControl.TabIndex = 1;
            this.imagePanelControl.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pcOstu);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1042, 719);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step 2: Binary(Ostu alg)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.PC_Eff);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1042, 719);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Step 2.1";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pcDenose);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1042, 719);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Step 2.2";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.pcBoNen);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1042, 719);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Step 3: Lung";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // pcBoNen
            // 
            this.pcBoNen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBoNen.Location = new System.Drawing.Point(3, 3);
            this.pcBoNen.Name = "pcBoNen";
            this.pcBoNen.Size = new System.Drawing.Size(1036, 713);
            this.pcBoNen.TabIndex = 17;
            this.pcBoNen.TabStop = false;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.denoiseFromStep3);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1042, 719);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // denoiseFromStep3
            // 
            this.denoiseFromStep3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.denoiseFromStep3.Location = new System.Drawing.Point(3, 3);
            this.denoiseFromStep3.Name = "denoiseFromStep3";
            this.denoiseFromStep3.Size = new System.Drawing.Size(1036, 713);
            this.denoiseFromStep3.TabIndex = 18;
            this.denoiseFromStep3.TabStop = false;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.blobsBrowser1);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(1042, 719);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "tabPage7";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // blobsBrowser1
            // 
            this.blobsBrowser1.Highlighting = DicomImageViewer.BlobsBrowser.HightlightType.Quadrilateral;
            this.blobsBrowser1.Location = new System.Drawing.Point(360, 238);
            this.blobsBrowser1.Name = "blobsBrowser1";
            this.blobsBrowser1.ShowRectangleAroundSelection = false;
            this.blobsBrowser1.Size = new System.Drawing.Size(322, 242);
            this.blobsBrowser1.TabIndex = 0;
            this.blobsBrowser1.Text = "blobsBrowser1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(121, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // windowLevelControl
            // 
            this.windowLevelControl.Location = new System.Drawing.Point(10, 300);
            this.windowLevelControl.Name = "windowLevelControl";
            this.windowLevelControl.Size = new System.Drawing.Size(165, 235);
            this.windowLevelControl.TabIndex = 10;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.pc_class);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(1042, 719);
            this.tabPage8.TabIndex = 7;
            this.tabPage8.Text = "tabPage8";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // pc_class
            // 
            this.pc_class.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pc_class.Location = new System.Drawing.Point(3, 3);
            this.pc_class.Name = "pc_class";
            this.pc_class.Size = new System.Drawing.Size(1036, 713);
            this.pc_class.TabIndex = 19;
            this.pc_class.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 733);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.OtsuThreshold);
            this.Controls.Add(this.gbViewSettings);
            this.Controls.Add(this.windowLevelControl);
            this.Controls.Add(this.bnResetWL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnTags);
            this.Controls.Add(this.bnOpen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DICOM Image Viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.gbViewSettings.ResumeLayout(false);
            this.gbViewSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOstu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Eff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDenose)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBoNen)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.denoiseFromStep3)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pc_class)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bnOpen;
        private ImagePanelControl imagePanelControl;
        private System.Windows.Forms.Button bnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bnTags;
        private System.Windows.Forms.Button bnResetWL;
        private WindowLevelGraphControl windowLevelControl;
        private System.Windows.Forms.GroupBox gbViewSettings;
        private System.Windows.Forms.RadioButton rbZoomfit;
        private System.Windows.Forms.RadioButton rbZoom1_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OtsuThreshold;
        private System.Windows.Forms.PictureBox pcOstu;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.PictureBox PC_Eff;
        private System.Windows.Forms.PictureBox pcDenose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.PictureBox pcBoNen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.PictureBox denoiseFromStep3;
        private System.Windows.Forms.TabPage tabPage7;
        private BlobsBrowser blobsBrowser1;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.PictureBox pc_class;
    }
}

