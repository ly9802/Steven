using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
/* this program is used to generate the random number that used as testing data
 this is one part of an assignment of analysis of program
 */
namespace GetRandomData
{
    class Program
    {
        static void Main(string[] args)
        {
             int total = 0;
             Console.WriteLine("Please input the maximum length of array(>2)");
             total = int.Parse(Console.ReadLine());
             int iseed = 100;
             Random rd1 = new Random(iseed); Random rd2 = new Random(iseed);
            Random rd3 = new Random(iseed); Random rd4 = new Random(iseed);
             StreamWriter File1 = new StreamWriter("PositiveInteger.txt");
             StreamWriter File2 = new StreamWriter("NegativeInteger.txt");
             StreamWriter File3 = new StreamWriter("PositiveDouble.txt");
             StreamWriter File4 = new StreamWriter("NegativeDouble.txt");
             StreamWriter File5 = new StreamWriter("Extreme.txt");
             for (int n=5; n<=total;n=n+1) {
                for (int i=0;i<n;i++) {
                    int temp1=rd1.Next(1,200000); File1.WriteLine("{0}", temp1);
                    int temp2 = -rd2.Next(1,200000); File2.WriteLine("{0}", temp2);
                    double temp3 = rd3.NextDouble(); File3.WriteLine("{0}", temp3);
                    double temp4 = -rd4.NextDouble(); File4.WriteLine("{0}", temp4);
                    File5.WriteLine("{0}",0);
                }
            }
            Console.WriteLine("Testing data has been generated already!");
            File1.Close(); File2.Close(); File3.Close(); File4.Close(); File5.Close();
            Console.ReadKey();
        }
    }
}
