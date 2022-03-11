using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{
    internal class ChillIterators
    {

        public static IEnumerable<int> GetEnumeration()
        {
            int i = 0;
            while (true)
            {
                yield return i++;
            }
        }


        public static void TestIterator()
        {

            //foreach (var item in GetEnumeration().Where(x => x % 2 == 0).Take(5)){Console.WriteLine(item);}


            MyEnumerator<int> myEn = new MyEnumerator<int>();

            for(int i = 0; i < 10; i++)
                myEn.Add(i);
            
            //foreach(var a in myEn)
              //  Console.WriteLine(a);

            foreach(var a in myEn.MyWhere(x => x % 2 == 0).MyTake(10))
                Console.WriteLine(a);
        }
    }

    internal class MyEnumerator<T>
    {
        public T[] _list = new T[0];
        public int Count => _list.Length;

        public T this[int index]
        {
            get => _list[index];
            set => _list[index] = value;
        }

        public void Add(T item)
        {
            T[] copy = new T[Count + 1];
            Array.Copy(_list, copy, Count);
            _list = new T[Count + 1];
            Array.Copy(copy, _list, Count);
            _list[Count - 1] = item;
        }

        public void Delete(int index)
        {
            if (index < 0 || index > Count - 1)
                throw new IndexOutOfRangeException();
            T[] copy = new T[Count];
            Array.Copy(_list, copy, Count);
            _list = new T[Count - 1];
            for (int i = 0, j = 0; i < Count; i++, j++)
            {
                if (j == index)
                    i--;
                else
                    _list[i] = copy[j];
            }
        }

        // |    Where Take
        // V

        public delegate bool InputFunc(T k);

        public MyEnumerator<T> MyWhere(InputFunc func)
        {
            MyEnumerator<T> whereRes = new MyEnumerator<T>();

            foreach (var tmp in _list)
            {
                if (func(tmp))
                    whereRes.Add(tmp);
            }
            return whereRes;
        }

        public MyEnumerator<T> MyTake(int num)
        {
            MyEnumerator<T> takeRes = new MyEnumerator<T>();
            int count = 0;
            
            foreach(var a in _list)
            {
                if (num == 0)
                    return takeRes;
                else if (count < num)
                    takeRes.Add(a);
                count++;
            }
            return takeRes;
        }


        // |    Enumerator 
        // V

        private int _index = -1;

        public object Current => _list[_index];

        public MyEnumerator<T> GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            if(_index == Count - 1)
            {
                Reset();
                return false;
            }

            _index++;
            return true;
        }

        public void Reset()
        {
            _index = - 1;
        }
    }
}
