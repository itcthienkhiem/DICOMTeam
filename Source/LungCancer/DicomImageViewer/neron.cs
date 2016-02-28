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
                    if (pc.GetPixel(i, j).R == 255 && pc.GetPixel(i, j).G == 255 && pc.GetPixel(i, j).B ==255 && !isexit(i, j))
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
                 System.IO.File.ReadAllLines (@"data.txt");
            foreach (var file in files)
            {
                String[] str = file.Split(';');
                org.SetPixel(int.Parse(str[0]), int.Parse(str[1]), Color.Yellow);
            }
            return org;
        }
        public void readfromfile2()
        {
            count = 0;
           // Bitmap org = (Bitmap)pc.Clone();
            String[] files =
                 System.IO.File.ReadAllLines(@"data.txt");
            foreach (var file in files)
            {
                String[] str = file.Split(';');
               // if (int.Parse(str[2]) == label)
                {
                    count++;
                    lstseglabel.Add(new segmentLabel(int.Parse(str[0]), int.Parse(str[1]), int.Parse(str[2])));
                  //  org.SetPixel(int.Parse(str[0]), int.Parse(str[1]), Color.Yellow);
                }
            }
          //  return org;
        }

        /// <summary>
        /// ve lai khoi u theo labewl cua bitmap
        /// </summary>
        /// <param name="pc"></param>
        /// <param name="label"></param>
        /// <returns></returns>
        public Bitmap readfromfile2(Bitmap pc,int label)
        {
            count = 0;
            Bitmap org = (Bitmap)pc.Clone();
            String[] files =
                 System.IO.File.ReadAllLines(@"data.txt");
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

       
        public List<segmentLabel> getAlllablesegment(int lable)
        {
            List<segmentLabel> lst = new List<segmentLabel>();
            for (int i=0; i<lstseglabel.Count;i++)
            {
                if(lstseglabel[i].label==lable)
                {
                    lst.Add(lstseglabel[i]);
                }
            }
            return lst;
        }
        public void writetofile()
        {
            System.IO.StreamWriter file = new 
                 System.IO.StreamWriter(@"data.txt", false);
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
        public int maxX(List<segmentLabel> lst)
        {
            int max = lst[0].x;
            for (int i=1;i<lst.Count;i++)
            {
                if(max<lst[i].x)
                {
                    max = lst[i].x;
                }
            }
            return max;
        }
        public int maxY(List<segmentLabel> lst)
        {
            int max = lst[0].y;
            for (int i = 1; i < lst.Count; i++)
            {
                if (max < lst[i].y)
                {
                    max = lst[i].y;
                }
            }
            return max;
        }
        public int minX(List<segmentLabel> lst)
        {
            int min = lst[0].x;
            for (int i = 1; i < lst.Count; i++)
            {
                if (min > lst[i].x)
                {
                    min = lst[i].x;
                }
            }
            return min;
        }
        public int minY(List<segmentLabel> lst)
        {
            int min = lst[0].y;
            for (int i = 1; i < lst.Count; i++)
            {
                if (min > lst[i].y)
                {
                    min = lst[i].y;
                }
            }
            return min;
        }
        public void lancanW(Bitmap org, int x, int y, int label)
        {
        //    List<segmentLabel>lstsegment = new List<segmentLabel>();
            // Bitmap org = new Bitmap(pcOstu.Image);
            List<Point> lst = new List<Point>();
            lst.Add(new Point(x, y));
            lstseglabel.Add(new segmentLabel(x, y, label));
           // lstsegment.Add(new segmentLabel(x, y, label));
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
