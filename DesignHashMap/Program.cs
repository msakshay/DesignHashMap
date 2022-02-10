using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignHashMap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyHashMap obj = new MyHashMap();
            obj.Put(2, 8);
            obj.Put(3, 9);
            int ParamVal = obj.Get(2);
            Console.WriteLine(ParamVal);
        }
    }

    public class MyHashMap
    {
        public class MyHash
        {
            public int Key { get; set; }
            public int Value { get; set; }
        }

        internal MyHash[] myHash;

        public MyHashMap()
        {
            myHash = new MyHash[1000];
        }

        public void Put(int key, int value)
        {
            int positionKey = GetHashKey(key);
            if (myHash[positionKey] == null)
                myHash[positionKey] = new MyHash { Key = key, Value = value };
            else
            {
                int i = GetHashKey(key);
                while (myHash[i] == null)
                {
                    myHash[i++] = new MyHash { Key = key, Value = value };
                    i = GetHashKey(i); 
                }
                //myHash.Add(new MyHash { Key = key, Value = value });
            }
        }

        public int Get(int key)
        {
            if(myHash[key].Key == key)
                return myHash[key].Value;
            else
            {
                int i = GetHashKey(key+1);
                while(myHash[i].Key != key && i!=key)
                {
                    i = GetHashKey(key);
                    i++;
                }
                if (i == key)
                    return -1;
                else
                    return myHash[i].Value;
            }
        }

        private int GetHashKey(int key)
        {
            return (key % 1000);
        }

        public void Remove(int key)
        {
            if (myHash[key].Key == key)
                myHash[key] = new MyHash();
            else
            {
                int i = GetHashKey(key + 1);
                while (myHash[i].Key != key && i != key)
                {
                    i = GetHashKey(key);
                    i++;
                }
                if (i == key)
                    return;
                else
                    myHash[i] = new MyHash();
            }
        }
    }
}
