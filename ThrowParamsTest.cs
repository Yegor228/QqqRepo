using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class ThrowParamsTest
    {
        public static void TestThrowFinal()
        {
            try
            {
                ThrowTest();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        static void ThrowTest()
        {

            try
            {
                throw new Exception("ALYARM!!!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /*
          With throw
             at Qqq.Program.ThrowTest() in C:\\Qqq\Program.cs:line 28 <- Тут сработало исключение
             at Qqq.Program.Main(String[] args) in C:\\Qqq\Program.cs:line 13
          With throw ex
            at Qqq.Program.ThrowTest() in C:\\Qqq\Program.cs:line 32 <- Генерация нового исключения и потеря строки, где произошло первое исключение
            at Qqq.Program.Main(String[] args) in C:\Users\egor5\OneDrive\Рабочий стол\Чикиряу\Qqq\Program.cs:line 13    
         */


        static void ActionParamIgnored()
        {
            Test(delegate { });

            static void Test(Action<int, int, int> runAfterWork)
            {
                runAfterWork(0, 1, 2);
            }
        }
    }
}
