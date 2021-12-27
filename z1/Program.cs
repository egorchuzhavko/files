using System;
using System.IO;
using System.Net.Mime;

namespace z1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во степеней числа 3: ");
            double s = Convert.ToDouble(Console.ReadLine());
            using (BinaryWriter bw = new BinaryWriter(File.Open(@"test.bin",FileMode.OpenOrCreate)))
            {
                for (double i = 1; i < s + 1; i++)
                {
                    bw.Write(Convert.ToInt32(Math.Pow(3, i)));
                }
            }
            Console.WriteLine();
            bool zn = false;
            using (BinaryReader br = new BinaryReader(File.Open(@"test.bin",FileMode.Open)))
            {
                while (br.BaseStream.Position!=br.BaseStream.Length)
                {
                    int q =br.ReadInt32();
                    if (zn)
                        Console.WriteLine(q);
                    zn = !zn;
                }
            }
        }
    }
}