using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;


namespace AlphaBcakend
{
    public class DIService 
    {
        public static IReadFile _IReadFile;
        public static IhandleXml _IhandleXml;

        public static HandleXml handle = new HandleXml();
        public static ReadFile read = new ReadFile();

        public DIService() => (_IReadFile, _IhandleXml) = (read, handle);
        
        internal void AggregateList()
        {
            handle.AggregateList();
        }

        internal void ProcessFile(string path)
        {
            handle.ProcessFile(path);
        }

        internal void ProcessDirectory(string path)
        {
            read.ProcessDirectory(path);
        }
    }
}