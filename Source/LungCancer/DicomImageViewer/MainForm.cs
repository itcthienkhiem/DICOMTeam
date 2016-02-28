using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Collections;

using System.Data.OleDb;
using System.IO;
// Program to view simple DICOM images.
// Written by Amarnath S, Mahesh Reddy S, Bangalore, India, April 2009.
// Updated along with Harsha T, April 2010 to include Window/Level
// Updated by Amarnath S, July 2010, to include Ultrasound images of 8-bit depth, 3 samples per pixel (RGB).
// Updated July 2012 to incorporate Zoom 1:1 and Zoom To Fit.
// Updated Aug 2013 to accommodate earlier DICOM files.

// Inspired by ImageJ

namespace DicomImageViewer
{
    public enum ImageBitsPerPixel { Eight, Sixteen, TwentyFour };
    public enum ViewSettings { Zoom1_1, ZoomToFit };

    /// <summary>
    /// This program reads in a DICOM file and displays it on the screen. 
    /// The functionality for viewer is:
    /// o Open DICOM files created as per DICOM 3.0 standard
    /// o Open files with Explicit VR and Implicit VR Transfer Syntax
    /// o Read those files where image bit depth is 8 or 16 bits (Digital Radiography), 
    ///    or RGB images (from Ultrasound)
    /// o Read a DICOM file with just one image inside it
    /// o Read a DICONDE file also (a DICONDE file is a DICOM file with NDE - Non Destructive   
    ///    Evaluation - tags inside it)
    /// o Read older DICOM files. Earlier DICOM files don't have the preamble and prefix, and 
    ///    just contain the string 1.2.840.10008 somewhere in the beginning
    /// o Perform Window/Level operations on the image.
    /// 
    /// This viewer is not intended to:
    /// o Check whether all mandatory tags are present
    /// o Open files with VR other than Explicit and Implicit - in particular, not to open 
    ///    JPEG Lossy and Lossless files

    /// o Read a sequence of images. 
    /// </summary>
    /// 

    public partial class MainForm : Form
    {
        DicomDecoder dd;
        List<byte> pixels8;
        List<ushort> pixels16;
        List<byte> pixels24; // 30 July 2010
        int imageWidth;
        int imageHeight;
        int bitDepth;
        int samplesPerPixel;  // Updated 30 July 2010
        bool imageOpened;
        double winCentre;
        double winWidth;
        bool signedImage;
        int maxPixelValue;    // Updated July 2012
        int minPixelValue;
        List<Point> edge = new List<Point>();
        int[,] arr = new int[2, 2];




        public void resetArray()
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                }
                //  arr[i,j] = 0;
            }
        }
        public bool get_checkpoint_edge(int x, int y)
        {
            for (int i = 0; i < edge.Count; i++)
            {
                if (edge[i].X == x && edge[i].Y == y)
                {
                    return true;
                }
            }
            return false;
        }

        private void ProcessImage(Bitmap image)
        {

            //    blobsCountLabel.Text = string.Format("Found blobs' count: {0}", foundBlobsCount);
            //    propertyGrid.SelectedObject = null;
        }
        public void get_edge()

        {

         //   Bitmap org = new Bitmap(denoiseFromStep3.Image);
            // Bitmap  temp =(Bitmap) imagePanelControl.getBitMap().Clone();
            //   Bitmap gsimage = Grayscale.CommonAlgorithms.BT709.Apply(temp);
            //SobelEdgeDetector filter = new SobelEdgeDetector();

            // filter.ApplyInPlace(org);
          //  ProcessImage(org);


            //        for(int i=1;i<temp.Width-1;i++)
            //        {
            //            for (int j = 1; j < temp.Height - 1; j++)
            //            {
            //                //XET DIEM DEN DAU TIEN
            //                /*
            //                00x
            //                011
            //                x1x
            //*/
            //                try
            //                {
            //                    //XET DIEM DEN DAU TIEN
            //                    /*
            //                    00x
            //                    011
            //                    x1x
            //    */
            //                    if (i + 1 < temp.Width && i - 1 >= 0 && j - 1 >= 0 && j + 1 < temp.Height)
            //                    {
            //                        if (temp.GetPixel(i, j).R == 0 && get_checkpoint_edge(i, j) == false && temp.GetPixel(i - 1, j).R == 255 && temp.GetPixel(i - 1, j - 1).R == 255
            //                            && temp.GetPixel(i, j + 1).R == 0 && temp.GetPixel(i + 1, j).R == 0 && temp.GetPixel(i, j - 1).R == 255)

            //                        {
            //                            //arr[1, 1] = -1;
            //                            edge.Add(new Point(i, j));
            //                        }
            //                        //XET DIEM DEN DAU TIEN
            //                        /*
            //                        x00
            //                        110
            //                        x1x
            //        */
            //                        if (temp.GetPixel(i, j).R == 0 && get_checkpoint_edge(i, j) == false
            //                            && temp.GetPixel(i - 1, j).R == 0 && temp.GetPixel(i + 1, j + 1).R == 255
            //                            && temp.GetPixel(i, j + 1).R == 0 && temp.GetPixel(i + 1, j).R == 255
            //                            && temp.GetPixel(i, j - 1).R == 255)

            //                        {
            //                            //arr[1, 1] = -1;
            //                            edge.Add(new Point(i, j));
            //                        }
            //                        /*
            //                       x1x
            //                       110
            //                       x00
            //       */
            //                        if (temp.GetPixel(i, j).R == 0 && get_checkpoint_edge(i, j) == false
            //                           && temp.GetPixel(i, j - 1).R == 0 && temp.GetPixel(i - 1, j).R == 0
            //                           && temp.GetPixel(i + 1, j).R == 255 && temp.GetPixel(i, j + 1).R == 255
            //                           && temp.GetPixel(i + 1, j + 1).R == 255)

            //                        {
            //                            //arr[1, 1] = -1;
            //                            edge.Add(new Point(i, j));
            //                        }
            //                        /*
            //                       x1x
            //                       011
            //                       00x
            //       */
            //                        if (temp.GetPixel(i, j).R == 0 && get_checkpoint_edge(i, j) == false
            //                           && temp.GetPixel(i, j - 1).R == 0 && temp.GetPixel(i - 1, j).R == 255
            //                           && temp.GetPixel(i + 1, j).R == 255 && temp.GetPixel(i - 1, j + 1).R == 255
            //                           && temp.GetPixel(i, j + 1).R == 255)
            //                        {
            //                            //arr[1, 1] = -1;
            //                            edge.Add(new Point(i, j));
            //                        }
            //                    }
            //                    //XET DIEM DEN TIEP THEO

            //                }
            //                catch (Exception ex) { MessageBox.Show("---->" + i); }

            //                }

            //        }
            //for(int i=0;i<edge.Count();i++)
            //{
            //    temp.SetPixel(edge[i].X, edge[i].Y, Color.Red);
            //}
            //   edge_from.Image = org;
        }
        public MainForm()
        {
            InitializeComponent();
            dd = new DicomDecoder();
            pixels8 = new List<byte>();
            pixels16 = new List<ushort>();
            pixels24 = new List<byte>();
            imageOpened = false;
            signedImage = false;
            maxPixelValue = 0;
            minPixelValue = 65535;
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All DICOM Files(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Length > 0)
                {
                    Cursor = Cursors.WaitCursor;
                    ReadAndDisplayDicomFile(ofd.FileName, ofd.SafeFileName);
                    imageOpened = true;
                    Cursor = Cursors.Default;
                }
                ofd.Dispose();
            }

        }

        private void ReadAndDisplayDicomFile(string fileName, string fileNameOnly)
        {
            dd.DicomFileName = fileName;

            TypeOfDicomFile typeOfDicomFile = dd.typeofDicomFile;

            if (typeOfDicomFile == TypeOfDicomFile.Dicom3File ||
                typeOfDicomFile == TypeOfDicomFile.DicomOldTypeFile)
            {
                imageWidth = dd.width;
                imageHeight = dd.height;
                bitDepth = dd.bitsAllocated;
                winCentre = dd.windowCentre;
                winWidth = dd.windowWidth;
                samplesPerPixel = dd.samplesPerPixel;
                signedImage = dd.signedImage;

                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                bnSave.Enabled = true;
                bnTags.Enabled = true;
                bnResetWL.Enabled = true;
                label2.Text = imageWidth.ToString() + " X " + imageHeight.ToString();
                if (samplesPerPixel == 1)
                    label4.Text = bitDepth.ToString() + " bit";
                else
                    label4.Text = bitDepth.ToString() + " bit, " + samplesPerPixel +
                        " samples per pixel";

                imagePanelControl.NewImage = true;
                Text = "DICOM Image Viewer: " + fileNameOnly;

                if (samplesPerPixel == 1 && bitDepth == 8)
                {
                    pixels8.Clear();
                    pixels16.Clear();
                    pixels24.Clear();
                    dd.GetPixels8(ref pixels8);

                    // This is primarily for debugging purposes, 
                    //  to view the pixel values as ascii data.
                    //if (true)
                    //{
                    //    System.IO.StreamWriter file = new System.IO.StreamWriter(
                    //               "C:\\imageSigned.txt");

                    //    for (int ik = 0; ik < pixels8.Count; ++ik)
                    //        file.Write(pixels8[ik] + "  ");

                    //    file.Close();
                    //}

                    minPixelValue = pixels8.Min();
                    maxPixelValue = pixels8.Max();

                    // Bug fix dated 24 Aug 2013 - for proper window/level of signed images
                    // Thanks to Matias Montroull from Argentina for pointing this out.
                    if (dd.signedImage)
                    {
                        winCentre -= char.MinValue;
                    }

                    if (Math.Abs(winWidth) < 0.001)
                    {
                        winWidth = maxPixelValue - minPixelValue;
                    }

                    if ((winCentre == 0) ||
                        (minPixelValue > winCentre) || (maxPixelValue < winCentre))
                    {
                        winCentre = (maxPixelValue + minPixelValue) / 2;
                    }

                    imagePanelControl.SetParameters(ref pixels8, imageWidth, imageHeight,
                        winWidth, winCentre, samplesPerPixel, true, this);
                }

                if (samplesPerPixel == 1 && bitDepth == 16)
                {
                    pixels16.Clear();
                    pixels8.Clear();
                    pixels24.Clear();
                    dd.GetPixels16(ref pixels16);

                    // This is primarily for debugging purposes, 
                    //  to view the pixel values as ascii data.
                    //if (true)
                    //{
                    //    System.IO.StreamWriter file = new System.IO.StreamWriter(
                    //               "C:\\imageSigned.txt");

                    //    for (int ik = 0; ik < pixels16.Count; ++ik)
                    //        file.Write(pixels16[ik] + "  ");

                    //    file.Close();
                    //}

                    minPixelValue = pixels16.Min();
                    maxPixelValue = pixels16.Max();

                    // Bug fix dated 24 Aug 2013 - for proper window/level of signed images
                    // Thanks to Matias Montroull from Argentina for pointing this out.
                    if (dd.signedImage)
                    {
                        winCentre -= short.MinValue;
                    }

                    if (Math.Abs(winWidth) < 0.001)
                    {
                        winWidth = maxPixelValue - minPixelValue;
                    }

                    if ((winCentre == 0) ||
                        (minPixelValue > winCentre) || (maxPixelValue < winCentre))
                    {
                        winCentre = (maxPixelValue + minPixelValue) / 2;
                    }

                    imagePanelControl.Signed16Image = dd.signedImage;

                    imagePanelControl.SetParameters(ref pixels16, imageWidth, imageHeight,
                        winWidth, winCentre, true, this);
                }

                if (samplesPerPixel == 3 && bitDepth == 8)
                {
                    // This is an RGB colour image
                    pixels8.Clear();
                    pixels16.Clear();
                    pixels24.Clear();
                    dd.GetPixels24(ref pixels24);

                    // This code segment is primarily for debugging purposes, 
                    //    to view the pixel values as ascii data.
                    //if (true)
                    //{
                    //    System.IO.StreamWriter file = new System.IO.StreamWriter(
                    //                      "C:\\image24.txt");

                    //    for (int ik = 0; ik < pixels24.Count; ++ik)
                    //        file.Write(pixels24[ik] + "  ");

                    //    file.Close();
                    //}

                    imagePanelControl.SetParameters(ref pixels24, imageWidth, imageHeight,
                        winWidth, winCentre, samplesPerPixel, true, this);
                }
            }
            else
            {
                if (typeOfDicomFile == TypeOfDicomFile.DicomUnknownTransferSyntax)
                {
                    MessageBox.Show("Sorry, I can't read a DICOM file with this Transfer Syntax.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Sorry, I can't open this file. " +
                        "This file does not appear to contain a DICOM image.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Text = "DICOM Image Viewer: ";
                // Show a plain grayscale image instead
                pixels8.Clear();
                pixels16.Clear();
                pixels24.Clear();
                samplesPerPixel = 1;

                imageWidth = imagePanelControl.Width - 25;   // 25 is a magic number
                imageHeight = imagePanelControl.Height - 25; // Same magic number
                int iNoPix = imageWidth * imageHeight;

                for (int i = 0; i < iNoPix; ++i)
                {
                    pixels8.Add(240);// 240 is the grayvalue corresponding to the Control colour
                }
                winWidth = 256;
                winCentre = 127;
                imagePanelControl.SetParameters(ref pixels8, imageWidth, imageHeight,
                    winWidth, winCentre, samplesPerPixel, true, this);
                imagePanelControl.Invalidate();
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                bnSave.Enabled = false;
                bnTags.Enabled = false;
                bnResetWL.Enabled = false;

            }

        }

        private void bnTags_Click(object sender, EventArgs e)
        {
            if (imageOpened == true)
            {
                List<string> str = dd.dicomInfo;

                DicomTagsForm dtg = new DicomTagsForm();
                dtg.SetString(ref str);
                dtg.ShowDialog();

                imagePanelControl.Invalidate();
            }
            else
                MessageBox.Show("Load a DICOM file before viewing tags!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            if (imageOpened == true)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PNG Files(*.png)|*.png";

                if (sfd.ShowDialog() == DialogResult.OK)
                    imagePanelControl.SaveImage(sfd.FileName);
            }
            else
                MessageBox.Show("Load a DICOM file before saving!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            imagePanelControl.Invalidate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            pixels8.Clear();
            pixels16.Clear();
            if (imagePanelControl != null) imagePanelControl.Dispose();
        }

        private void bnResetWL_Click(object sender, EventArgs e)
        {
            if ((pixels8.Count > 0) || (pixels16.Count > 0) || (pixels24.Count > 0))
            {
                imagePanelControl.ResetValues();
                if (bitDepth == 8)
                {
                    if (samplesPerPixel == 1)
                        imagePanelControl.SetParameters(ref pixels8, imageWidth, imageHeight,
                            winWidth, winCentre, samplesPerPixel, false, this);
                    else // samplesPerPixel == 3
                        imagePanelControl.SetParameters(ref pixels24, imageWidth, imageHeight,
                        winWidth, winCentre, samplesPerPixel, false, this);
                }

                if (bitDepth == 16)
                    imagePanelControl.SetParameters(ref pixels16, imageWidth, imageHeight,
                        winWidth, winCentre, false, this);
            }
            else
                MessageBox.Show("Load a DICOM file before resetting!", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void UpdateWindowLevel(int winWidth, int winCentre, ImageBitsPerPixel bpp)
        {
            int winMin = Convert.ToInt32(winCentre - 0.5 * winWidth);
            int winMax = winMin + winWidth;
            this.windowLevelControl.SetWindowWidthCentre(winMin, winMax, winWidth, winCentre, bpp, signedImage);
        }

        private void viewSettingsCheckedChanged(object sender, EventArgs e)
        {
            if (rbZoom1_1.Checked)
            {
                imagePanelControl.viewSettings = ViewSettings.Zoom1_1;
            }
            else
            {
                imagePanelControl.viewSettings = ViewSettings.ZoomToFit;
            }

            imagePanelControl.viewSettingsChanged = true;
            imagePanelControl.Invalidate();
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// hàm này view histogram
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void viewHistogram()
        {

            //  int grayscale = (orgcol.R + orgcol.G + orgcol.B) / 3;

            Bitmap h = MyHistogram.CreateHistogram(imagePanelControl.getBitMap(), false);
            pictureBox1.Image = h;
        }
        public void LanCanBon(Bitmap bmp)
        {

        }

        public
            bool isStatus(int x, int y, List<Point> lst)
        {
            for (int t = 0; t < lst.Count; t++)
            {
                if (lst[t].X == x && lst[t].Y == y)
                {
                    return true;
                }
            }
            return false;
        }
        public void ToLoang(Bitmap temp, int x, int y)
        {

        }
        public void BoBien()
        {
            Bitmap bmpOStu = new Bitmap(pcOstu.Image);




            ToLoang(bmpOStu, 1, 1);

            pcBoNen.Image = bmpOStu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            BinaryImages();
           // switchImages();
            //deNoise();
           
            getLung();
           
         //   neron nr = new neron();

        //    pictureBox3.Image = nr.readfromfile2((Bitmap)pc_class.Image, 0);
        }
        /// <summary>
        /// hàm nhị phân hóa ảnh
        /// </summary>
        private void BinaryImages()
        {
            Otsu ot = new Otsu();
            Bitmap org = imagePanelControl.getBitMap();
            Bitmap temp = (Bitmap)org.Clone();
            ot.Convert2GrayScaleFast(temp);
            int otsuThreshold = ot.getOtsuThreshold((Bitmap)temp);
            ot.threshold(temp, otsuThreshold);//set value to images
            pcOstu.Image = temp;
            textBox3.Text = otsuThreshold.ToString();
        }
        /// <summary>
        /// chuyen doi nguoc anh 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void switchImages()
        {
            Bitmap org = new Bitmap(pcOstu.Image);
            Bitmap temp = (Bitmap)org.Clone();
            for (int i = 0; i < temp.Width; i++)
            {
                for (int j = 0; j < temp.Height; j++)
                {
                    if (temp.GetPixel(i, j).R == 0)
                    {
                        temp.SetPixel(i, j, Color.White);
                    }
                    else
                        temp.SetPixel(i, j, Color.Black);
                }
            }
            //PC_Eff.Image = temp;
        }
        /// <summary>
        /// làm mịn các điểm ảnh nhiểu dựa vào lân cận 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void deNoise()
        //{
        //    Bitmap org = new Bitmap(PC_Eff.Image);
        //    Bitmap temp = (Bitmap)org.Clone();
        //    //for (int n = 0; n < 5; n++)
        //    {
        //        for (int i = 1; i < temp.Width - 1; i++)
        //        {

        //            for (int j = 1; j < temp.Height - 1; j++)
        //            {
        //                if (temp.GetPixel(i, j).R == 255)
        //                {
        //                    int count = 0;
        //                    if (temp.GetPixel(i - 1, j).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i, j + 1).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i - 1, j - 1).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i + 1, j + 1).R == 0)
        //                        count++;
        //                    if (count >= 3)
        //                    {
        //                        temp.SetPixel(i, j, Color.Black);
        //                    }

        //                }
        //                else
        //                {
        //                    int cout = 0;
        //                    if (temp.GetPixel(i - 1, j).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i, j + 1).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i - 1, j - 1).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i + 1, j + 1).R == 255)
        //                        cout++;
        //                    if (cout >= 3)
        //                        temp.SetPixel(i, j, Color.White);
        //                }
        //            }
        //        }
        //    }
        //    //pcDenose.Image = temp;

        //}
        public int getTrangDau(Bitmap bmp, int k)
        {
            for (int i = 0; i < bmp.Width; i++)
                if (bmp.GetPixel(i, k).R == 255)
                {
                    return i;
                }
            return -1;
        }
        public int getTrangCuoi(Bitmap bmp, int k)
        {
            for (int i = bmp.Width - 1; i >= 0; i--)
                if (bmp.GetPixel(i, k).R == 255)
                {
                    return i;
                }
            return -1;
        }
        public void BoNenQuyet(Bitmap btm)
        {
            List<Point> lst = new List<Point>();
            lst.Add(new Point(0, 0));
            while (lst.Count != 0)
            {
                Point p = lst[0];
                btm.SetPixel(p.X, p.Y, Color.White);
                if (p.X + 1 >= 0 && p.X + 1 < btm.Width)
                {
                    if (btm.GetPixel(p.X + 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < btm.Width)
                {
                    if (btm.GetPixel(p.X - 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < btm.Height)
                {
                    if (btm.GetPixel(p.X, p.Y + 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < btm.Width)
                {
                    if (btm.GetPixel(p.X, p.Y - 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                    }
                }

            }
        }
        /// <summary>
        /// làm mịn điểm ảnh, sau khi tách phổi
        /// </summary>
        //public void denoise_step3()
        //{
        //    Bitmap temp = new Bitmap(pcBoNen.Image);

        //    {
        //        for (int i = 1; i < temp.Width - 1; i++)
        //        {

        //            for (int j = 1; j < temp.Height - 1; j++)
        //            {
        //                if (temp.GetPixel(i, j).R == 255)
        //                {
        //                    int count = 0;
        //                    if (temp.GetPixel(i - 1, j).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i, j + 1).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i - 1, j - 1).R == 0)
        //                        count++;
        //                    if (temp.GetPixel(i + 1, j + 1).R == 0)
        //                        count++;
        //                    if (count >= 3)
        //                    {
        //                        temp.SetPixel(i, j, Color.Black);
        //                    }

        //                }
        //                else
        //                {
        //                    int cout = 0;
        //                    if (temp.GetPixel(i - 1, j).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i, j + 1).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i - 1, j - 1).R == 255)
        //                        cout++;
        //                    if (temp.GetPixel(i + 1, j + 1).R == 255)
        //                        cout++;
        //                    if (cout >= 3)
        //                        temp.SetPixel(i, j, Color.White);
        //                }
        //            }
        //        }
        //    }
        //    denoiseFromStep3.Image = temp;
        //}
        /// <summary>
        /// hàm tách phổi 
        /// </summary>
        private void getLung()
        {
           // lineOfLine();
            //org = getLungCanter(0, org.Height-1, new Bitmap(org));
            //org = getLungCanter(org.Width-1, 0, new Bitmap(org));
            //org = getLungCanter(org.Width-1, org.Height-1, new Bitmap(org));
            Bitmap org = getLungCanter(0, 0,new Bitmap( pcOstu.Image));
            
           
           // int color = org.GetPixel(0, org.Width).R;
           // denoise_step3();
         //   get_edge();

           // Bitmap org = new Bitmap(pcBoNen.Image);
           
            classter(0,0,org);
            for (int i = 0; i < org.Width; i++)
                if (org.GetPixel(i, 0).R == 0)

                    classterRemoveBlackEDGE(i, 0, org);
                else
                    if (org.GetPixel(i, 0).R == 255)
                        classter(i, 0,org);

            for (int i = 0; i < org.Width; i++)
                if (org.GetPixel(0, i).R == 0)

                    classterRemoveBlackEDGE(0, i, org);
                else
                    if (org.GetPixel(0, i).R == 255)
                        classter(0, i, org);
           
            for (int i = 0; i < org.Width; i++)
                if (org.GetPixel(org.Width -1, i).R == 0)

                    classterRemoveBlackEDGE(org.Width - 1, i, org);
                else
                    if (org.GetPixel(org.Width - 1, i).R == 255)
                        classter(org.Width - 1, i, org);
            for (int i = 0; i < org.Width; i++)
                if (org.GetPixel(i, org.Height -1).R == 0)

                    classterRemoveBlackEDGE(i, org.Height - 1, org);
                else
                    if (org.GetPixel(i, org.Height - 1).R == 255)
                        classter(i, org.Height - 1, org);
            pcBoNen.Image = org;
//            classter(org.Width-1, org.Height-1);
       //     classter(0, org.Height-1);
        //    classter(org.Width-1, 0);
        //    classter(0, 930);
           neron listfile = new neron();
            //Bitmap bmp  = new Bitmap(pc_class.Image);
             

            listfile.ShellInputData(org);
            
     //       pictureBox3.Image =
     //       listfile.readfromfile2(new Bitmap(pc_class.Image),0);
        }

        public Boolean isexit(int x, int y, List <Point > p )
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].X == x && p[i].Y == y)
                {
                    return true;

                }

            }
            return false;
        }
        /// <summary>
        /// hàm xác định số thành phần liên thông trong đồ thị 
        /// </summary>
        private void lineOfLine(Bitmap org)
        {
            ShellInputData(org);
         
            
        }
        public void ShellInputData(Bitmap pc)
        {
            int label = 0;
            List<Point> lst = new List<Point>();
            List<Object> lstObject = new List<Object>();
            for (int i = 0; i < pc.Width; i++)
            {
                for (int j = 0; j < pc.Height; j++)
                {
                    //mau den 
                    if (pc.GetPixel(i, j).R == 0 && pc.GetPixel(i, j).G == 0 && pc.GetPixel(i, j).B == 0 && !isexit(i, j, lst))
                    {

                      List<Point> p =  lancanW(pc, i, j, label,lst);
                        
                      lstObject.Add(p);
                        label++;
                    }
                }

            }
           // writetofile();
        }
        /// <summary>
        /// p mang danh dau 
        /// </summary>
        /// <param name="org"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="label"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public List<Point> lancanW(Bitmap org, int x, int y, int label,List<Point> ps )
        {
            //    List<segmentLabel>lstsegment = new List<segmentLabel>();
            // Bitmap org = new Bitmap(pcOstu.Image);
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));
            //danh dau trong 1 thanh phan lien thong 
            List<Point> lstTemp = new List<Point>();
            lstTemp .Add (new Point (x,y));
            ps.Add(new Point(x, y));
          //  lst.Add(new segmentLabel(x, y, label));
            // lstsegment.Add(new segmentLabel(x, y, label));
            while (lst.Count != 0)
            {
                Point p = lst[0];
                lst.RemoveAt(0);

                if (p.X + 1 >= 0 && p.X + 1 < org.Width && !isexit(p.X + 1, p.Y,lstTemp))
                {
                    if (org.GetPixel(p.X + 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                        lstTemp.Add(new Point(p.X + 1, p.Y));
                        ps.Add(new Point(p.X + 1, p.Y));
                     //   lstseglabel.Add(new segmentLabel(p.X + 1, p.Y, label));
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < org.Width && !isexit(p.X - 1, p.Y, lstTemp))
                {
                    if (org.GetPixel(p.X - 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                        lstTemp.Add(new Point(p.X - 1, p.Y)); ps.Add(new Point(p.X - 1, p.Y));
                      //  lstseglabel.Add(new segmentLabel(p.X - 1, p.Y, label));
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < org.Height && !isexit(p.X, p.Y + 1,lstTemp))
                {
                    if (org.GetPixel(p.X, p.Y + 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                        lstTemp.Add(new Point(p.X, p.Y + 1)); ps.Add(new Point(p.X, p.Y + 1));
                       // lstseglabel.Add(new segmentLabel(p.X, p.Y + 1, label));
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < org.Width && !isexit(p.X, p.Y - 1, lstTemp))
                {
                    if (org.GetPixel(p.X, p.Y - 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                        lstTemp.Add(new Point(p.X, p.Y - 1)); ps.Add(new Point(p.X, p.Y - 1));
                     //   lstseglabel.Add(new segmentLabel(p.X, p.Y - 1, label));
                    }
                }

            }
            return lstTemp;
        }
        private Bitmap getLungCanter(int x,int y,Bitmap bmp)
        {
            Bitmap org = bmp;
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));

         
           

            while (lst.Count != 0)
            {
                Point p = lst[0];
                lst.RemoveAt(0);


                org.SetPixel(p.X, p.Y, Color.White);
                if (p.X + 1 >= 0 && p.X + 1 < org.Width)
                {
                    if (org.GetPixel(p.X + 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                        org.SetPixel(p.X + 1, p.Y, Color.White);
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < org.Width)
                {
                    if (org.GetPixel(p.X - 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                        org.SetPixel(p.X - 1, p.Y, Color.White);
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < org.Height)
                {
                    if (org.GetPixel(p.X, p.Y + 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                        org.SetPixel(p.X, p.Y + 1, Color.White);
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < org.Width)
                {
                    if (org.GetPixel(p.X, p.Y - 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                        org.SetPixel(p.X, p.Y - 1, Color.White);
                    }
                }

            }
            return org;
        }

        //private void button1_Click_1(object sender, EventArgs e)
        //{
        //    Bitmap org = new Bitmap(pcOstu.Image);
        //    List<Point> lst = new List<Point>();
        //    lst.Add(new Point(0, 0));
        //    while (lst.Count != 0)
        //    {
        //        Point p = lst[0];
        //        lst.RemoveAt(0);
        //        org.SetPixel(p.X, p.Y, Color.White);
        //        if (p.X + 1 >= 0 && p.X + 1 < org.Width)
        //        {
        //            if (org.GetPixel(p.X + 1, p.Y).R == 0)
        //            {
        //                lst.Add(new Point(p.X + 1, p.Y));
        //                org.SetPixel(p.X + 1, p.Y, Color.White);
        //            }
        //        }
        //        if (p.X - 1 >= 0 && p.X - 1 < org.Width)
        //        {
        //            if (org.GetPixel(p.X - 1, p.Y).R == 0)
        //            {
        //                lst.Add(new Point(p.X - 1, p.Y));
        //                org.SetPixel(p.X - 1, p.Y, Color.White);
        //            }
        //        }
        //        if (p.Y + 1 >= 0 && p.Y + 1 < org.Height)
        //        {
        //            if (org.GetPixel(p.X, p.Y + 1).R == 0)
        //            {
        //                lst.Add(new Point(p.X, p.Y + 1));
        //                org.SetPixel(p.X, p.Y + 1, Color.White);
        //            }
        //        }
        //        if (p.Y - 1 >= 0 && p.Y - 1 < org.Width)
        //        {
        //            if (org.GetPixel(p.X, p.Y - 1).R == 0)
        //            {
        //                lst.Add(new Point(p.X, p.Y - 1));
        //                org.SetPixel(p.X, p.Y - 1, Color.White);
        //            }
        //        }

        //    }

        //    pcBoNen.Image = org;
        //    denoise_step3();
        //    get_edge();
        //    classter(0,0);
        //    classter(0, 930);
        //    neron listfile = new neron();
        //    listfile.ShellInputData(new Bitmap(pc_class.Image));
        //    //pc_class.Image =
        //    //listfile.readfromfile(new Bitmap(pc_class.Image));
        //}
        public void classterRemoveBlackEDGE(int x, int y, Bitmap org)
        {
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));
            while (lst.Count != 0)
            {
                Point p = lst[0];
                lst.RemoveAt(0);


                org.SetPixel(p.X, p.Y, Color.LightSlateGray);
                if (p.X + 1 >= 0 && p.X + 1 < org.Width)
                {
                    if (org.GetPixel(p.X + 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                        org.SetPixel(p.X + 1, p.Y, Color.LightSlateGray);
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < org.Width)
                {
                    if (org.GetPixel(p.X - 1, p.Y).R == 0)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                        org.SetPixel(p.X - 1, p.Y, Color.LightSlateGray);
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < org.Height)
                {
                    if (org.GetPixel(p.X, p.Y + 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                        org.SetPixel(p.X, p.Y + 1, Color.LightSlateGray);
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < org.Width)
                {
                    if (org.GetPixel(p.X, p.Y - 1).R == 0)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                        org.SetPixel(p.X, p.Y - 1, Color.LightSlateGray);
                    }
                }

            }

            //            pc_class.Image = org;

            //get_edge();
        }
        public void classter(int x,int y,Bitmap org )
        {
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));
            while (lst.Count != 0)
            {
                Point p = lst[0];
                lst.RemoveAt(0);

              
                org.SetPixel(p.X, p.Y, Color.LightSlateGray);
                if (p.X + 1 >= 0 && p.X + 1 < org.Width)
                {
                    if (org.GetPixel(p.X + 1, p.Y).R == 255)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                        org.SetPixel(p.X + 1, p.Y, Color.LightSlateGray);
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < org.Width)
                {
                    if (org.GetPixel(p.X - 1, p.Y).R == 255)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                        org.SetPixel(p.X - 1, p.Y, Color.LightSlateGray);
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < org.Height)
                {
                    if (org.GetPixel(p.X, p.Y + 1).R == 255)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                        org.SetPixel(p.X, p.Y + 1, Color.LightSlateGray);
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < org.Width)
                {
                    if (org.GetPixel(p.X, p.Y - 1).R == 255)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                        org.SetPixel(p.X, p.Y - 1, Color.LightSlateGray);
                    }
                }

            }

//            pc_class.Image = org;

            //get_edge();
        }

        public void saveInputModel( )
        {

            Bitmap pmb = new Bitmap(pcBoNen.Width, pcBoNen.Height);
            neron nr = new neron();
            nr.readfromfile2();
            List<int[,]> lstarray = new List<int[,]>();
            for (int t = 0; t < nr.lstseglabel[nr.lstseglabel.Count - 1].label; t++)
            {

                List<segmentLabel> lst = new List<segmentLabel>();
                lst = nr.getAlllablesegment(t);
                int maxX = nr.maxX(lst) - nr.minX(lst);
                int maxY = nr.maxY(lst) - nr.minY(lst);
                int[,] arr = new int[60, 60];

                for (int i = 0; i < lst.Count; i++)
                {

                    {
                        arr[lst[i].x - nr.minX(lst), lst[i].y - nr.minY(lst)] = 1;
                    }
                }
                lstarray.Add(arr);

            }
            for (int t = 0; t < nr.lstseglabel[nr.lstseglabel.Count - 1].label; t++)
            {
                Bitmap bmp = new Bitmap(60, 60);
                for (int i = 0; i < lstarray[t].GetLength(0); i++)

                    for (int j = 0; j < lstarray[t].GetLength(1); j++)
                    {
                        if (lstarray[t][i, j] == 0)
                        {
                            bmp.SetPixel(i, j, Color.White);
                        }
                        else
                            bmp.SetPixel(i, j, Color.Black);
                    }
                bmp.Save("input/" + t.ToString() + ".png");

            }
           
        }
        public void testALL()
        {
            String[] filename = Directory.GetFiles("input");
            if (filename.Count() == 0)
            {   
                MessageBox.Show("không có dữ liệu ảnh input");
                return;
            }
            List<bool> lstResult = new List<bool>();
            for (int i = 0; i < filename.Length; i++)
            {
                modelNeuron model = new modelNeuron();
                bool result = model.testmachine(filename[i].ToString());
                lstResult.Add(result);
            }
            Bitmap bmpResult = imagePanelControl.getBitMap();
            for (int i = 0; i < lstResult.Count(); i++)
            {
                if(lstResult[i]==true)
                {
                    neron nr = new neron();
                    bmpResult = nr.readfromfile2(bmpResult, i);
                    
                }
            }
            resultALL.Image = bmpResult;
        }
        private void bt_inputneuron_Click(object sender, EventArgs e)
        {
            saveInputModel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            testALL();

        }
    }
}