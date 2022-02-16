using System;

namespace Qqq
{
    internal class Program
    {
        [Flags]
        public enum UserSettings : int
        {
            None = 0,
            CanReadComments = 1,
            CanWriteComments = 2,
            CanDeleteComments = 4,
        }

        static void Main(string[] args)
        {
            //TestDia();
            //TestStruct();
            //TestOnStrings();
            //TestFunc();
            //TestAction();

            TestActionsWithInvoker();
        }



        static void TestActionsWithInvoker()
        {
            Action a = () =>
            {
                Console.WriteLine("HI!");
                Console.WriteLine("HI!");
                Console.WriteLine("HI!");

            };

            a();
            a.Invoke();
            a.DynamicInvoke();
        }

        static void TestAction()
        {
            Action[] actions = new Action[5];

            for (int i = 0; i < 5; i++)
            {
                int j = i;
                actions[i] = () => Console.WriteLine(j);
            }
            actions[2]();
        }


        static void TestFunc()
        {
            Func<int> f = null;

            f += () =>
            {
                Console.WriteLine("A");
                //throw new Exception();
                return 1;
            };
            f += () =>
            {
                Console.WriteLine("B");
                return 2;
            };
            Console.WriteLine(f());
        }

        static void TestOnStrings()
        {
            var str1 = "123";
            string str2 = "123";

            var a = String.IsInterned(str2.ToString());
            Console.WriteLine(a);
            Console.WriteLine($"{str1 == str2} vs {str1.Equals(str2)} vs {ReferenceEquals(str2, a)}");
        }

        static void TestStruct()
        {
            var myObj = new MyClass();

            var test = myObj.GetTest();


            myObj.GetTest();

            Console.WriteLine(myObj.GetTest(5).Value);
        }

        static void TestDia()
        {
            var arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            foreach (var a in arr[new Range(^5, ^0)])
                Console.WriteLine(a);
        }

        static void CheckFlags()
        {
            Console.WriteLine("Hello World!");

            var role1 = UserSettings.CanWriteComments | UserSettings.CanReadComments | UserSettings.CanDeleteComments;

            Console.WriteLine(role1 & UserSettings.CanWriteComments);
            Console.WriteLine(role1 & UserSettings.CanReadComments);
            Console.WriteLine(role1 & UserSettings.CanDeleteComments);
            role1 ^= UserSettings.CanWriteComments;
            role1 ^= UserSettings.CanReadComments;
            role1 ^= UserSettings.CanDeleteComments;
            Console.WriteLine(role1 & UserSettings.CanWriteComments);
            Console.WriteLine(role1 & UserSettings.CanReadComments);
            Console.WriteLine(role1 & UserSettings.CanDeleteComments);

        }
    }

    public struct Test
    {
        public int Value { get; set; }

        public Test(int sss)
        {
            Value = sss;
        }

    }

    public class MyClass
    {
        private Test _test;

        public Test GetTest(int k) => _test = new Test(k);

        public Test GetTest() => _test;

    }
}
