using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBcakend
{
    public class ReadFile: IReadFile
    {
        private readonly IhandleXml _IhandleXml = new HandleXml();
        public ReadFile ()
        {
            
        }
 

        public void ProcessDirectory(string targetDirectory)
        {
            try
            {
                // Process the list of files found in the directory.
                string[] fileEntries = Directory.GetFiles(targetDirectory, "Trades*.xml");
                foreach (string fileName in fileEntries)
                    _IhandleXml.ProcessFile(fileName);

                // Recurse into subdirectories of this directory.
                string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
                foreach (string subdirectory in subdirectoryEntries)
                    ProcessDirectory(subdirectory);
            }
            catch (Exception e)
            {
                throw;
            }

        }

    }
}
