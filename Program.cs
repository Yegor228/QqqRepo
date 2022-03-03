using System;
using System.IO;

namespace Qqq
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //TestException();
            //TestTestTestDispose();
            TestUsing();
        }


        static void TestUsing()
        {
            using(FileStream fr = new FileStream("qqq.jpg", FileMode.Open))
            {
                try
                {
                    byte[] buffer = new byte[fr.Length];
                    var tmp = fr.Read(buffer, 0, buffer.Length);
                    Console.WriteLine(tmp);
                    //foreach (var a in buffer)
                    //  Console.Write(a + " ");
                    fr.Dispose();
                    throw new ObjectDisposedException(nameof(fr));
                }
                catch(ObjectDisposedException e)
                {
                    Console.WriteLine(e.Message);
                }
                
            }
        }

        static void TestTestTestDispose()
        {
            DisposeTest dt = new DisposeTest();

            dt.SomeMethod();

            dt.Dispose();
        }

        static void TestException()
        {
            int testNum = 120;
            try 
            {    
                if(testNum > 100)
                throw new Exception<BadNumberExceptionArgs>(
                    new BadNumberExceptionArgs(testNum), "Bad number!");
            }
            catch(Exception<BadNumberExceptionArgs> e) when (testNum == 130)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void ActionParamIgnored()
        {
            /*
            //Test((Test<int, int, int>));

            Test((_,_,_) => Console.WriteLine("LOG"));
                
            static void Test(Action<int, int, int> runAfterWork)
            {
                runAfterWork(0, 1, 2);
            }*/
        }
    }
}
