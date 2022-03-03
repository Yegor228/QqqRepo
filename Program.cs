using System;

namespace Qqq
{
    internal class Program
    {
       
        static void Main(string[] args)
        {
            //TestException();


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
