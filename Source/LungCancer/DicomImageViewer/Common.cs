using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DicomImageViewer
{
public    class Common
    {
        public static void writetofile(string path, double data)
        {
            System.IO.StreamWriter file = new
                 System.IO.StreamWriter(path, false);
            {
                file.WriteLine(data);
            }
            file.Flush();
            file.Close();

        }
        public static void writetofile(string path, double[] data)
        {
            System.IO.StreamWriter file = new
                 System.IO.StreamWriter(path, false);
            foreach (var item in data)
            {
                file.WriteLine(item);
            }
            file.Flush();
            file.Close();

        }
        public static double[] readonfile(string path)
        {
            String[] files =
      System.IO.File.ReadAllLines(path);
            double[] data = new double[files.Count()];

            for (int i=0; i<files.Count();i++)
            {
                data[i] =double.Parse( files[i]);
            }
            return data;

        }
        public static double readonfilebestbias(string path)
        {
            String[] files =
      System.IO.File.ReadAllLines(path);
//            double[] data = new double[files.Count()];

            
            return double.Parse(files[0]); ;

        }

    }
}
