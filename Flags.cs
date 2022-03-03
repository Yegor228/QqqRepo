using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class Flags
    {
        [Flags]
        public enum UserSettings : int
        {
            None = 0,
            CanReadComments = 1,
            CanWriteComments = 2,
            CanDeleteComments = 4,
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
}
