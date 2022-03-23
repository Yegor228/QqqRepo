using System;
using System.Collections.Generic;
using System.Linq;

namespace Qqq
{
    internal class Lists
    {
        public List<Weather> Weathers;
        public List<Person> Persons;
        public Lists()
        {
            Persons = new List<Person>
            {
                new Person() { Name = "Alexey", City = "Moscow"},
                new Person() { Name = "Viktor", City = "St.Peterburg"},
                new Person() { Name = "Sergey", City = "Vladimir"},
                new Person() { Name = "Alexander", City = "Vladimir"}
            };
            Weathers = new List<Weather>
            {
                new Weather() { Now = "Solar", City = "Moscow"},
                new Weather() { Now = "Rainy", City = "Tallin"},
                new Weather() { Now = "Snowy", City = "Vladimir"}
            };
        }

        public void JoinLists()
        {
            ILookup<string, string> tmp = Persons.ToLookup(p => p.City, t => t.Name);
            ILookup<string, string> tmp2 = Weathers.ToLookup(p => p.City, t => t.Now);

            var join = tmp.GroupJoin(tmp2, p => p.Key, s => s.Key, (w, s) => new { City = w.Key, Name = tmp[w.Key], Now = tmp2[w.Key] });

            foreach (var a in join)
            {
                Console.WriteLine(a.City + " ");
                foreach (var b in a.Name)
                {
                    Console.WriteLine("\t" + b);
                        foreach (var c in a.Now)
                            Console.WriteLine("\t\t" + c );
                }
                    
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public string City { get; set; }

    }

    public class Weather
    {
        public string Now { get; set; }
        public string City { get; set; }
    }
}
