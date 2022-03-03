using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class DisposeTest : IDisposable
    {

        public void SomeMethod()
        {
            Action act = () => Console.WriteLine("QQQQQQQQ");

            act.Invoke();
        }

        public void Dispose() 
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                Console.WriteLine("Освободил управляемые ресурсы!");
                return;
            }
            Console.WriteLine("Ууу... Освобождаю неуправляемые ресурсы!");
            disposing = true;
        }
        ~DisposeTest()
        {
            Dispose(false);
        }
    }
}
