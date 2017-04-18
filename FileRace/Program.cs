using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileRace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(@"
Enter Command
    R : read 10 sec
    W : write 10 sec
    RC : read 10 sec and crash
    WC : write 10 sec and crash
");
            var cmd = Console.ReadLine().ToLower();
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = Path.Combine(exeDir, "test.txt");

            if (cmd == "r")
            {
                var fs = File.OpenRead(filePath);
                var sr = new StreamReader(fs);

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"wait i : {i} ...");
                }

                var fileText = sr.ReadToEnd();
                Console.WriteLine($"fileText : {fileText}");

                sr.Dispose();
                fs.Dispose();
            }
            else if (cmd == "w")
            {
                var fs = File.OpenWrite(filePath);
                var sw = new StreamWriter(fs);

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"wait i : {i} ...");
                }

                sw.WriteLine(DateTime.Now.ToString("yyMMdd-HHmmss"));
                sw.Dispose();
                fs.Dispose();
            }
            else if (cmd == "rc")
            {
                var fs = File.OpenRead(filePath);
                var sr = new StreamReader(fs);

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"wait i : {i} ...");
                }

                var fileText = sr.ReadToEnd();
                Console.WriteLine($"fileText : {fileText}");

                throw new Exception("my ex !!!");

                sr.Dispose();
                fs.Dispose();
            }
            else if (cmd == "wc")
            {
                var fs = File.OpenWrite(filePath);
                var sw = new StreamWriter(fs);

                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"wait i : {i} ...");
                }

                sw.WriteLine(DateTime.Now.ToString("yyMMdd-HHmmss"));

                throw new Exception("my ex !!!");

                sw.Dispose();
                fs.Dispose();
            }
        }
    }
}
