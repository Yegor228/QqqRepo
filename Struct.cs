using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class Struct
    {
        static void TestStruct()
        {
            var myObj = new MyClass();
            var test = myObj.GetTest;
            Console.WriteLine(myObj.GetTest.Value);

            test.Value = 10;
            myObj.GetTest = test;
            Console.WriteLine(myObj.GetTest.Value);

            test.Value = 50;
            myObj.GetTest = test;
            Console.WriteLine(myObj.GetTest.Value);
        }
    }

    public struct Test
    {
        public int Value { get; set; }

    }

    public class MyClass
    {
        private Test _test = new() { Value = 1 };

        public Test GetTest
        {
            get { return _test; }
            set { _test = value; }
        }

    }
}
