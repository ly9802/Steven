using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
/* this program is used to get the execution time and the numbers the basic operation runs for two algorithms
the testing data is generated by the program named " random number generation". 
this is a main part of the assignment of analysis of program
*/
namespace MindistanceInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 0;
            int total = 100;
            StreamReader PositiveInteger = new StreamReader("PositiveInteger.txt");
            StreamWriter PIF1 = new StreamWriter("PItime.txt", false);
            PIF1.WriteLine("Length,Algorithm1,Algorithm2");
            StreamWriter PIF2 = new StreamWriter("PIbp.txt", false);
            PIF2.WriteLine("Length,Algortihm1,Algorithm2");
            StreamWriter Minidistance = new StreamWriter("Minidistnace.txt");
            Minidistance.WriteLine("This file is used to display the samllest distance.");
            for (n=5;n<=total;n=n+1) {
                Minidistance.WriteLine("n={0}",n);
                //read the testing data from a file
                int[] a = new int[n];
                for (int i = 0; i < n; i=i+1) {
                    a[i] = int.Parse(PositiveInteger.ReadLine());
                    Minidistance.WriteLine("a[{0}]={1}",i,a[i]);
                }
                // invoke sub-method and record the time used respectively
                 TimeSpan t1 ; int amout1 = 0;
                 TimeSpan t2 ; int amout2 = 0;
                 int testtimes = 100;
                TimeSpan ts3 = new TimeSpan(0);
                double minidistance1 = 0.0;
                for (int i = 0; i < testtimes; i++) {
                    Stopwatch s1 = new Stopwatch(); s1.Start();
                    minidistance1=MinDistance1(a, out t1, out amout1);
                    s1.Stop();
                    ts3=ts3+s1.Elapsed-t1;
                }
                TimeSpan ts4 = new TimeSpan(0);
                double minidistance2 = 0.0;
                for(int i = 0; i < testtimes; i++) {
                    Stopwatch s2 = new Stopwatch(); s2.Start();
                    minidistance2=MinDistance2(a, out t2, out amout2);
                    s2.Stop();
                    ts4= ts4+s2.Elapsed-t2;
                }
                Minidistance.WriteLine("The smallest distance for algorithm1 is {0}",minidistance1);
                Minidistance.WriteLine("The smallest distance for algorithm2 is {0}",minidistance2);
                // write the ruslut(time and numbers of basic operation) into two file respectively
                PIF1.WriteLine("{0},{1},{2}\n", n, ts3.TotalMilliseconds/testtimes, ts4.TotalMilliseconds/testtimes);
                PIF2.WriteLine("{0},{1},{2}\n", n, amout1,amout2);
                
            }
            Console.WriteLine("All the data have been stored,Please enter any key to return!!");
            PositiveInteger.Close();
            PIF1.Close();
            PIF2.Close();
            Minidistance.Close();
            Console.ReadKey();
        }
        static double MinDistance1(int[] a, out TimeSpan t1, out int n1)
        {   double dmin = 999999999.0;int number = 0;
            TimeSpan sumtime1=new TimeSpan(0);
            for (int i = 0; i < a.Length; i++){
                for (int j = 0; j < a.Length; j++){
                    if  (i != j) {
                        Stopwatch st = new Stopwatch();
                        st.Start();number++;st.Stop();
                        sumtime1 = sumtime1+st.Elapsed;
                        if (Math.Abs(a[i] - a[j]) < dmin) { dmin = Math.Abs(a[i] - a[j]);}    
                     }
                }
            }
            n1 = number;t1 = sumtime1;
            return dmin;
        }
        static double MinDistance2(int[] a,out TimeSpan t2,out int n2)
        {   double dmin = 999999999.0; int number = 0;
            TimeSpan sumtime2 = new TimeSpan(0);
            for (int i = 0; i < a.Length - 1; i++){
                for (int j = i + 1; j < a.Length; j++){
                    Stopwatch sw = new Stopwatch();
                    sw.Start();number++; sw.Stop();
                    sumtime2 = sumtime2 + sw.Elapsed;
                    double temp = Math.Abs(a[i] - a[j]);
                    if (temp < dmin){dmin = temp;}   
                }
            }
             n2 = number;t2 = sumtime2;
             return dmin;
        }
    }
}
