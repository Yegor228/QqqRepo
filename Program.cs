using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;

namespace Qqq
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            CheckDict();
            //CheckList();
            //CheckPrint();
            //ChillIterators.TestIterator();
            //ThrowParamsTest.TestThrowFinal();
        }


        public struct TestData
        {
            public string Data { get; set; }

            public override bool Equals(object obj)
            {
                if(Data != null && obj is string s)
                    return Data.Equals(s);
                return false;
            }
            public override int GetHashCode() => Data.Length;

        }

        static void CheckDict()
        {
            Dictionary<TestData, int> d = new Dictionary<TestData, int>();
            d.Add(new TestData { Data = "aaaa" }, 1);
            d.Add(new TestData { Data = "bbbb" }, 2);
            d.Add(new TestData { Data = "cccc" }, 3);
            foreach (var a in d)
                Console.WriteLine($"{a.Key.Data} - {a.Value} - HashDode - {a.Key.GetHashCode()}");
            Console.WriteLine(d.Keys.Count);
            Console.WriteLine("---------------------------------");
            d.Add(new TestData { Data = "dddd" }, 4);
            foreach (var a in d)
                Console.WriteLine($"{a.Key.Data} - {a.Value} - HashDode - {a.Key.GetHashCode()}");
            Console.WriteLine(d.Keys.Count);
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
