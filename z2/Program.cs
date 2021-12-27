using System;
using System.IO;

namespace z2
{
    class Program
    {
        static void Main(string[] args)
        {
            int k = 0;
            foreach(string s in File.ReadAllLines("z2.txt"))
                if (s[0] == s[s.Length - 1])
                    k++;
            Console.WriteLine("Кол-во строк: " + k);
        }
    }
}