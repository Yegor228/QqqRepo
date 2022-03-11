using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class Struct
    {
        public static void TestStruct()
        {
            var myObj = new MyClass();

            myObj.GetTest().Value = 20;

            Console.WriteLine(myObj.GetTest().Value);
            
        }
    }

    public struct Test
    {
        public int Value { get; set; }

    }

    public class MyClass
    {
        private Test _test = new () { Value = 1 };

        public ref Test GetTest() => ref _test;

    }
}
