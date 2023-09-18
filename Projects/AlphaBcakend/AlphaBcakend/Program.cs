using System;
using System.IO;

namespace AlphaBcakend
{
    class Program
    {

        public Program()
        {

        }
        static void Main(string[] args)
        {

            DIService service = new DIService();
            string[] dirs = Directory.GetDirectories(@"C:\Users\Mutaset Tamimi\Desktop\Engineer Code Test\Backend\Test");
            foreach (string path in dirs)
            {
                if (File.Exists(path))
                {
                    // This path is a file
                    if (! String.IsNullOrEmpty(Directory.GetFiles(path, "Trades*.xml").ToString()))
                    service.ProcessFile(path);
                }
                else if (Directory.Exists(path))
                {
                    // This path is a directory
                    service.ProcessDirectory(path);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", path);
                }
            }

            service.AggregateList();

        }
    }
}
