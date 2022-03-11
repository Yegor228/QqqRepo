using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Qqq
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            CheckList();
            //CheckPrint();
            //ChillIterators.TestIterator();
            //ThrowParamsTest.TestThrowFinal();
        }


        static void CheckList()
        {
            var list = new List<int>() { 1, 2, 3 };

            foreach (var item in list)
                list.Add(0);
            /*
             var item = list.GetEnumerator();
             while(item.MoveNext()) {
             int tmp = item.Current;
            }
             */

        }
        static void CheckPrint()
        {
            int i = 0;
            var data = Enumerable.Range(0, 5).Select(x =>
            {
                i++;
                return x;
            });

            Console.WriteLine(data.Count());
            Console.WriteLine(data.Max());
            Console.WriteLine(data.Min());

            Console.WriteLine(i);
        }

        
    }
}
