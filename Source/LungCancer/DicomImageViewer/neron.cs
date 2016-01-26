using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DicomImageViewer
{
    class neron
    {
      public  List<segmentLabel> lstseglabel = new List<segmentLabel>();
        public int count = 0;
        public void ShellInputData (Bitmap pc)
        {
            int label= 0;
            for(int i=0; i<pc.Width; i++)
            {
                for (int j = 0; j < pc.Height; j++)
                {
                    if(pc.GetPixel(i,j).R==255 &&! isexit(i,j))
                    {
                        lancanW(pc, i, j,label);
                        label++;
                    }
                }

            }
            writetofile();
        }
        public Bitmap readfromfile(Bitmap pc)
        {
            Bitmap org =(Bitmap) pc.Clone();
            String[] files = 
                 System.IO.File.ReadAllLines (@"C:\Users\An\Desktop\DICOMTeam.git\trunk\Source\LungCancer\data.txt");
            foreach (var file in files)
            {
                String[] str = file.Split(';');
                org.SetPixel(int.Parse(str[0]), int.Parse(str[1]), Color.Yellow);
            }
            return org;
        }

        public Bitmap readfromfile2(Bitmap pc,int label)
        {
            count = 0;
            Bitmap org = (Bitmap)pc.Clone();
            String[] files =
                 System.IO.File.ReadAllLines(@"C:\Users\An\Desktop\DICOMTeam.git\trunk\Source\LungCancer\data.txt");
            foreach (var file in files)
            {
                String[] str = file.Split(';');
                if (int.Parse(str[2]) == label)
                {
                    count ++;
                    lstseglabel.Add(new segmentLabel( int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2])));
                        org.SetPixel(int.Parse(str[0]), int.Parse(str[1]), Color.Yellow);
            }
            }
            return org;
        }
        public void writetofile()
        {
            System.IO.StreamWriter file = new 
                 System.IO.StreamWriter(@"C:\Users\An\Desktop\DICOMTeam.git\trunk\Source\LungCancer\data.txt", false);
            foreach (var item in lstseglabel)
            {
                string line = item.x + ";" + item.y + ";" + item.label;
                file.WriteLine(line);
            }
            file.Flush();
            file.Close();
            
        }
        public Boolean isexit(int x, int y)
        {
            for(int i=0; i<lstseglabel.Count;i++)
            {
                if(lstseglabel[i].x==x&& lstseglabel[i].y == y)
                {
                    return true;

                }

            }
            return false;
        }
        public int maxX()
        {
            int max = lstseglabel[0].x;
            for (int i=1;i<lstseglabel.Count;i++)
            {
                if(max<lstseglabel[i].x)
                {
                    max = lstseglabel[i].x;
                }
            }
            return max;
        }
        public int maxY()
        {
            int max = lstseglabel[0].y;
            for (int i = 1; i < lstseglabel.Count; i++)
            {
                if (max < lstseglabel[i].y)
                {
                    max = lstseglabel[i].y;
                }
            }
            return max;
        }
        public int minX()
        {
            int min = lstseglabel[0].x;
            for (int i = 1; i < lstseglabel.Count; i++)
            {
                if (min > lstseglabel[i].x)
                {
                    min = lstseglabel[i].x;
                }
            }
            return min;
        }
        public int minY()
        {
            int min = lstseglabel[0].x;
            for (int i = 1; i < lstseglabel.Count; i++)
            {
                if (min > lstseglabel[i].y)
                {
                    min = lstseglabel[i].y;
                }
            }
            return min;
        }
        public void lancanW(Bitmap org, int x, int y, int label)
        {
            lstseglabel.Clear();
            // Bitmap org = new Bitmap(pcOstu.Image);
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));
            lstseglabel.Add(new segmentLabel(x, y, label));

            while (lst.Count != 0)
            {
                Point p = lst[0];
                lst.RemoveAt(0);
                
                if (p.X + 1 >= 0 && p.X + 1 < org.Width&&!isexit(p.X+1, p.Y))
                {
                    if (org.GetPixel(p.X + 1, p.Y).R == 255)
                    {
                        lst.Add(new Point(p.X + 1, p.Y));
                        lstseglabel.Add(new segmentLabel(p.X+1, p.Y, label));
                    }
                }
                if (p.X - 1 >= 0 && p.X - 1 < org.Width && !isexit(p.X - 1, p.Y))
                {
                    if (org.GetPixel(p.X - 1, p.Y).R == 255)
                    {
                        lst.Add(new Point(p.X - 1, p.Y));
                        lstseglabel.Add(new segmentLabel(p.X-1, p.Y, label));
                    }
                }
                if (p.Y + 1 >= 0 && p.Y + 1 < org.Height && !isexit(p.X , p.Y+1))
                {
                    if (org.GetPixel(p.X, p.Y + 1).R == 255)
                    {
                        lst.Add(new Point(p.X, p.Y + 1));
                        lstseglabel.Add(new segmentLabel(p.X, p.Y+1, label));
                    }
                }
                if (p.Y - 1 >= 0 && p.Y - 1 < org.Width && !isexit(p.X , p.Y-1))
                {
                    if (org.GetPixel(p.X, p.Y - 1).R == 255)
                    {
                        lst.Add(new Point(p.X, p.Y - 1));
                        lstseglabel.Add(new segmentLabel(p.X, p.Y-1, label));
                    }
                }

            }
        }
    }
}
