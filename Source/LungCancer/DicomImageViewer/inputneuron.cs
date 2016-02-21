using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DicomImageViewer
{
    public class inputneuron
    {
        List<List<int>> lstarrays = new List<List<int>>();
        public void readpng(int t, string path)
        {
            String[] filename = Directory.GetFiles(path);
            if (filename.Count() == 0)
            {
                MessageBox.Show("không có dữ liệu ảnh input");
                return;
            }
            foreach (var item in filename)
            {
                List<int> lstarray = new List<int>();
                Bitmap img = (Bitmap)Image.FromFile(item);
                if (img != null)
                {
                    //int count = 0;
                    for (int i = 0; i < img.Width; i++)
                    {
                        for (int j = 0; j < img.Height; j++)
                        {
                            if (img.GetPixel(i, j).R == 0)
                                lstarray.Add(1);
                            else
                                lstarray.Add(0);
                        }
                    }
                }
                lstarray.Add(t);
                lstarrays.Add(lstarray);
            }
        }
        public void readAll()
        {
            readpng(0, "FP");
            readpng(1, "TP");

        }
    }
}
