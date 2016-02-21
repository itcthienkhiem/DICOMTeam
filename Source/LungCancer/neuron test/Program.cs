using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace neuron_test
{
    class Program
    {
        static void Main(string[] args)
        {
            modelNeuron nr = new modelNeuron();
            //  nr.readAll();
           nr.testmachine();
           // nr.testmachine();
           // nr.learnFunction();
            
            Console.ReadKey();
        }
    }
}
