using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Задача_21
{
    internal class Program
    {
        const int n = 10;
        static int[,] path  = new int[n, n];
        static void Main(string[] args)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    path[i, j]=0;
                }
            }
            ThreadStart threadStart1 = new ThreadStart(Gardener1);
            Thread thread1 = new Thread(threadStart1);
            thread1.Start();
            Gardener2();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write($"{path[i, j]} ");
                Console.ReadKey();
            }
        }






            static void Gardener1()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (path[i, j]>=0)
                        {
                        int delay = path[i, j];
                            path[i, j] = 1;
                        Thread.Sleep(delay);
                        }
                    }
                }
            }
            static void Gardener2()
            {
                for (int j = n-1;j>=0;j--)
                {
                    for (int i = n-1; i>=0; i--)
                    {
                        if (path[i, j]>=0)
                        {
                        int delay = path[i, j];
                        path[i, j] = 2;
                        Thread.Sleep(delay);
                    }
                    }
                }
            }

        
    }
}
