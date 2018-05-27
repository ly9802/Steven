using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace MindistanceInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int total = 1000;
            int irandomseed = 6;
            StreamWriter F1 = new StreamWriter("time1.txt", false);
            F1.WriteLine("Length,Algorithm1,Algorithm2");
            StreamWriter F2 = new StreamWriter("basicoperation.txt", false);
            F2.WriteLine("Length,Algortihm1,Algorithm2");
            int amout1 = 0;
            int amout2 = 0;
            for (n=10;n<=total;n=n+10) { 
                double[] a = new double[n];
                Random randomNumber = new Random(irandomseed);
                for (int i = 0; i < n; i=i+1) {
                    a[i] = randomNumber.Next(1, 100000000);
                }
                Stopwatch sd = new Stopwatch(); sd.Start();
                Console.WriteLine("The smallest distance for 1 is {0}", MinDistance1(a,out amout1));
                sd.Stop(); TimeSpan ts3 = sd.Elapsed;
                Stopwatch st = new Stopwatch(); st.Start();
                Console.WriteLine("The smallest distance for 2 is {0}", MinDistance2(a,out amout2));
                st.Stop();TimeSpan ts4 = st.Elapsed;
                F1.WriteLine("{0},{1},{2}\n", n, ts3.TotalMilliseconds, ts4.TotalMilliseconds);
                F2.WriteLine("{0},{1},{2}\n", n, amout1,amout2);
             }
            F1.Close();
            F2.Close();
            Console.WriteLine("All the data have been stored, Please enter any key to return!!!");
            Console.ReadKey();
        }
        static double MinDistance1(double[] a, out int n1)
        {
            double dmin = 999999999.0;
            int number = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length; j++)
                {
                    if  (i != j) {
                        number++;
                        if (Math.Abs(a[i] - a[j]) < dmin) { 
                            dmin = Math.Abs(a[i] - a[j]);
                          }
                     }
                }
            }
            n1 = number;
            return dmin;
        }
        static double MinDistance2(double[] a,out int n2)
        {
            
           
            double dmin = 999999999.0;
            int number = 0;
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    number++;
                    if (Math.Abs(a[i] - a[j]) < dmin)
                    {
                        dmin = Math.Abs(a[i] - a[j]);
                        
                    }
                }
            }

            n2 = number;
            
            return dmin;
        }
    }
}
