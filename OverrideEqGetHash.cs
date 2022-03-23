using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class OverrideEqGetHash
    {
        public static void Test()
        {
            KeyEqualityComparer kEqComp = new KeyEqualityComparer();
            Dictionary<Id, string> data = new Dictionary<Id, string>(kEqComp);

            data[new Id { Value = 10}] = "Ivanov";
            data[new Id { Value = 11 }] = "Qqq";
            data[new Id { Value = 12 }] = "Www";
            data[new Id { Value = 13 }] = "Eeee";
            
            foreach(var a in data)
                Console.WriteLine(a.Key.Value + "\t" +  a.Value);

        }
    }

    public class KeyEqualityComparer : IEqualityComparer<Id>
    {
        public bool Equals(Id x, Id y)
        {
            if (x == null && y == null)
                return true;
            else if (x == null || y == null)
                return false;
            else if (x.Value == y.Value)
                return true;
            else
                return false;
        }

        public int GetHashCode(Id id) => (int)id.Value>>1;
    }



    public class Id
    {
        public long Value { get; set; }
    }
}
