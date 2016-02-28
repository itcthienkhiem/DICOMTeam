using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DicomImageViewer;


namespace DicomImageViewer
{
    public class modelNeuron
    {
        List<List<int>> lstarrays = new List<List<int>>();
        public void readpng(int t, string path)
        {
            String[] filename = Directory.GetFiles(path);
            if (filename.Count() == 0)
            {
               
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
        /// <summary>
        /// chuyen doi tu bitmap sang list<>
        /// item : duong dan file bitmap
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public List<int> readafile(string item)
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
            return lstarray;
        }
        /// <summary>
        /// doc thu muc training 
        /// </summary>
        public void readAll()
        {
            readpng(0, @"FP\");
            readpng(1, @"TP\");

        }

        public static void ShowVector(double[] vector)
        {
            for (int i = 0; i < vector.Length; ++i)
            {
                if (i > 0 && i % 60 == 0) Console.WriteLine("");
                Console.Write(vector[i].ToString("+0.000;-0.000") + " ");
            }
            Console.WriteLine("");
        }
        /// <summary>
        /// ham hoc 
        /// </summary>
        public void learnFunction()
        {
            readAll();
            int maxEpochs = 1000;
            double alpha = 0.075;
            double targetError = 0.0;

            double bestBias = 0.0;
            double[] bestWeights = FindBestWeights(maxEpochs, alpha, targetError, out bestBias);
            DicomImageViewer.Common.writetofile("bestBias.txt", bestBias);
            DicomImageViewer.Common.writetofile("bestWeights.txt", bestWeights);

         //   show();
        }
        public void  show()
        {

            double[] data = DicomImageViewer.Common.readonfile("bestWeights.txt");
            for (int i = 0; i < data.Count(); i++)
                Console.WriteLine(data[i] + "\n");
            Console.WriteLine( DicomImageViewer.Common.readonfilebestbias("bestBias.txt"));
            Console.WriteLine(data.Count());

        }
        /// <summary>
        /// ham test 
        /// </summary>
        public Boolean testmachine(string path)
        {


            double bestBias = DicomImageViewer.Common.readonfilebestbias("bestBias.txt");
            double[] bestWeights = DicomImageViewer.Common.readonfile("bestWeights.txt");


       //     ShowVector(bestWeights);
            
            double totalError = TotalError( bestWeights, bestBias);
            
            ////int[] dataVector = new int[] { 0, 1, 0, 1, 1,      0, 0, 0, 0, 0,     0, 1, 0, 0, 1,     0, 1, 0, 0, 1,    0, 1, 0, 1, 1 };  // damaged '0' -> should give 0 (not a '1' or '3')
            //int[] dataVector = new int[] { 0, 0, 1, 1, 1,    0, 0, 0, 0, 1,    0, 0, 0, 1, 1,    0, 0, 0, 0, 0,    0, 1, 1, 1, 1 };  // damaged '3' -> should give 1 (is a '1' or '3')
            //Console.WriteLine("\nPredicting is a '1' or '3' (yes = 1, no = 0) for the following pattern:\n");
            //ShowData(dataVector);

            List<int> unknown = readafile(path); // damaged 'B' in 2 positions

            int prediction = Predict(unknown, bestWeights, bestBias);  // perform the classification
            if (prediction == 0)return false;
            else return true;
        }
        public  int Predict(List <int> dataVector, double[] bestWeights, double bestBias)
        {
            double dotP = 0.0;
            for (int j = 0; j < dataVector.Count; ++j)  // all bits
                dotP += (dataVector[j] * bestWeights[j]);
            dotP += bestBias;
            return StepFunction(dotP);
        }
        public  double[] FindBestWeights( int maxEpochs, double alpha, double targetError, out double bestBias)
        {
            int dim = lstarrays[0].Count - 1;
            double[] weights = new double[dim];  // implicitly all 0.0
            double bias = 0.05;
            double totalError = double.MaxValue;
            int epoch = 0;

            while (epoch < maxEpochs && totalError > targetError)
            //while (epoch < maxEpochs)
            {
                for (int i = 0; i < lstarrays.Count; ++i)  // each training vector
                {
                    int desired = lstarrays[i][lstarrays[i].Count - 1];  // last bit
                    int output = ComputeOutput(lstarrays[i], weights, bias);
                    int delta = desired - output;  // -1 (if output too large), 0 (output correct), or +1 (output too small)

                    for (int j = 0; j < weights.Length; ++j)
                        weights[j] = weights[j] + (alpha * delta * lstarrays[i][j]);  // corrects weight

                    bias = bias + (alpha * delta);
                }

                totalError = TotalError( weights, bias);  // rescans; could do in for loop
                ++epoch;
            }
            bestBias = bias;
            return weights;
        }
        public static int ComputeOutput(List< int> trainVector, double[] weights, double bias)
        {
            double dotP = 0.0;
            for (int j = 0; j < trainVector.Count - 1; ++j)  // not last bit which is the desired
                dotP += (trainVector[j] * weights[j]);
            dotP += bias;
            return StepFunction(dotP);
        }
        public static int StepFunction(double x)
        {
            if (x > 0.5) return 1; else return 0;
        }
        public  double TotalError( double[] weights, double bias)
        {
            double sum = 0.0;
            for (int i = 0; i < lstarrays.Count; ++i)
            {
                int desired = lstarrays[i][lstarrays[i].Count - 1];
                int output = ComputeOutput(lstarrays[i], weights, bias);
                sum += (desired - output) * (desired - output);  // equivalent to Abs(desired - output) in this case
            }
            return 0.5 * sum;
        }

    }
}
