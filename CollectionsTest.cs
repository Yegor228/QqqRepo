using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class CollectionsTest
    {

        struct Test
        {
            public int Flag { get; set; }
            public int Value { get; set; }
        }

        public static void TestColl()
        {
            var coll = new[]
            {
                new Test { Flag = 1, Value = 10 },
                new Test { Flag = 3, Value = 6 },
                new Test { Flag = 4, Value = 8 },
                new Test { Flag = 5, Value = 10 },
                new Test { Flag = 5, Value = 10 },
                new Test { Flag = 5, Value = 10 }
            };

            //var t1 = coll.ToDictionary(x => x.Flag);
            var t2 = coll.ToLookup(x => x.Flag);
            var t3 = coll.GroupBy(x => x.Flag);
            var t4 = coll.ToHashSet();

            //foreach (var a in t1)
            //    Console.WriteLine($"key:{a.Key} = flag:{a.Value.Flag} value:{a.Value.Value} ");
            //Console.WriteLine("---------------");
            foreach (var a in t2)
                foreach (var s in a)
                    Console.WriteLine($"key:{a.Key} = flag:{s.Flag} value:{s.Value}");
            Console.WriteLine("----------------");
            foreach (var a in t3)
                foreach(var b in a)
                    Console.WriteLine($"key:{a.Key} = flag:{b.Flag} value:{b.Value}");
            Console.WriteLine("--------------");
            foreach (var a in t4)
                Console.WriteLine($"flag:{a.Flag}, value:{a.Value}");
        }
    }
}
