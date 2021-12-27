using System;
using System.IO;

namespace z3
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory(@"C:\\temp\\K1");
            Directory.CreateDirectory(@"C:\\temp\\K2");
            using(StreamWriter sw = new StreamWriter(@"C:\\temp\\K1\t1.txt"))
            {
                sw.WriteLine("Иванов Иван Иванович, 1965 года рождения, место жительства г. Саратов");
            }
            using (StreamWriter sw = new StreamWriter(@"C:\\temp\\K1\t2.txt"))
            {
                sw.WriteLine("Петров Сергей Федорович, 1966 года рождения, место жительства г. Энгельс");
            }
            using (StreamWriter sw = new StreamWriter(@"C:\\temp\\K2\t3.txt"))
            {
                using (StreamReader sr = new StreamReader(@"C:\\temp\\K1\t1.txt"))
                {
                    sw.WriteLine(sr.ReadLine());
                }
                using (StreamReader sr = new StreamReader(@"C:\\temp\\K1\t2.txt"))
                {
                    sw.WriteLine(sr.ReadLine());
                }
            }
            DirectoryInfo di = new DirectoryInfo(@"C:\\temp\\K2");
            FileInfo[] fi = di.GetFiles();
            foreach(var fii in fi)
            {
                Console.WriteLine(fii.FullName.ToString());
            }
            File.Move(@"C:\\temp\\K1\\t2.txt", @"C:\\temp\\K2\\t2.txt");
            File.Copy(@"C:\\temp\\K1\\t1.txt", @"C:\\temp\\K2\\t1.txt");
            Directory.Move(@"C:\\temp\\K2", @"C:\\temp\\ALL");
            Directory.Delete(@"C:\\temp\\K1", true);
            DirectoryInfo di1 = new DirectoryInfo(@"C:\\temp\\ALL");
            FileInfo[] fi1 = di1.GetFiles();
            foreach (var fii in fi1)
            {
                Console.WriteLine(fii.FullName.ToString());
            }
        }
    }
}