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
            this.windowLevelControl = new DicomImageViewer.WindowLevelGraphControl();
            this.imagePanelControl = new DicomImageViewer.ImagePanelControl();
            this.gbViewSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOstu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PC_Eff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcDenose)).BeginInit();
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
            this.pictureBox1.Location = new System.Drawing.Point(585, 9);
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
            this.pcOstu.Location = new System.Drawing.Point(185, 385);
            this.pcOstu.Name = "pcOstu";
            this.pcOstu.Size = new System.Drawing.Size(397, 261);
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
            this.PC_Eff.Location = new System.Drawing.Point(587, 385);
            this.PC_Eff.Name = "PC_Eff";
            this.PC_Eff.Size = new System.Drawing.Size(344, 261);
            this.PC_Eff.TabIndex = 19;
            this.PC_Eff.TabStop = false;
            // 
            // pcDenose
            // 
            this.pcDenose.Location = new System.Drawing.Point(937, 385);
            this.pcDenose.Name = "pcDenose";
            this.pcDenose.Size = new System.Drawing.Size(296, 261);
            this.pcDenose.TabIndex = 21;
            this.pcDenose.TabStop = false;
            // 
            // windowLevelControl
            // 
            this.windowLevelControl.Location = new System.Drawing.Point(10, 300);
            this.windowLevelControl.Name = "windowLevelControl";
            this.windowLevelControl.Size = new System.Drawing.Size(165, 235);
            this.windowLevelControl.TabIndex = 10;
            // 
            // imagePanelControl
            // 
            this.imagePanelControl.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.imagePanelControl.BackColor = System.Drawing.SystemColors.Control;
            this.imagePanelControl.CausesValidation = false;
            this.imagePanelControl.Location = new System.Drawing.Point(185, 9);
            this.imagePanelControl.Name = "imagePanelControl";
            this.imagePanelControl.Size = new System.Drawing.Size(394, 354);
            this.imagePanelControl.TabIndex = 1;
            this.imagePanelControl.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 733);
            this.Controls.Add(this.pcDenose);
            this.Controls.Add(this.PC_Eff);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.pcOstu);
            this.Controls.Add(this.OtsuThreshold);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gbViewSettings);
            this.Controls.Add(this.windowLevelControl);
            this.Controls.Add(this.bnResetWL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bnSave);
            this.Controls.Add(this.bnTags);
            this.Controls.Add(this.imagePanelControl);
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
    }
}

