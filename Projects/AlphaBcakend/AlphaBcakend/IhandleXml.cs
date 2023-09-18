using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaBcakend
{
    public interface IhandleXml
    {
        public void ProcessFile(string path);
        public void AggregateList();
    }
}
