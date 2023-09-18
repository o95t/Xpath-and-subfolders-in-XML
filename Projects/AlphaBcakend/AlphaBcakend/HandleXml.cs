using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AlphaBcakend
{
    public class HandleXml: IhandleXml
    {
        public static List<Securities> AKM = new List<Securities>();
        public static List<Securities> BKM = new List<Securities>();
        public static List<Securities> CKM = new List<Securities>();

        public void ProcessFile(string path)
        {
            int InvaildSec = 0;
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                string fileName = path;
                // uncomment the below line to read all name XML file  
                // Console.WriteLine("Processed file '{0}'.", fileName);
                xmlDoc.Load(path);
                XmlNodeList itemNodes = xmlDoc.SelectNodes("//trades/trade");
                foreach (XmlNode Node in itemNodes)
                {
                    InvaildSec = 0;
                    Securities securities = new Securities();
                    securities.BloombergId = Node.ChildNodes[10].ChildNodes[1].InnerXml;
                    securities.TransactionCode = Node.ChildNodes[4].InnerXml;
                    securities.TradeDate = Node.ChildNodes[1].InnerXml;
                    securities.Quantity = Decimal.Parse(Node.ChildNodes[5].InnerXml);
                    securities.Price = Decimal.Parse(Node.ChildNodes[8].InnerXml);

                    switch (securities.BloombergId)
                    {
                        case "AKM4JZ7":
                            AKM.Add(securities);
                            break;
                        case "BKM4JZ7":
                            BKM.Add(securities);
                            break;
                        case "CKM4JZ7":
                            CKM.Add(securities);
                            break;
                        default:
                            InvaildSec++;
                            break;
                    }

                }
                if (InvaildSec > 0)
                {
                  Console.WriteLine(" '{0}' Number Of  invalid Security '{1}'.", fileName, InvaildSec);
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void AggregateList()
        {
            // First List
            decimal AKMTotalQuan = AKM.Sum(item => item.Quantity);
            decimal AKMTotalPrice = AKM.Sum(item => item.Price);
            decimal AKMAvgPrice = AKMTotalPrice / AKM.Count();

            var AggAKM = AKM.GroupBy(e => (e.BloombergId, e.TransactionCode, e.TradeDate)).ToList();

            Console.WriteLine("summary  AKM4JZ7");

            Console.WriteLine("BloombergId => {0}", AggAKM[0].Key.BloombergId);
            Console.WriteLine("TransactionCode => {0}", AggAKM[0].Key.TransactionCode);
            Console.WriteLine("TradeDate => {0}", AggAKM[0].Key.TradeDate);
            Console.WriteLine("Sum on Quantity => {0}", AKMTotalQuan);
            Console.WriteLine("Average Price => {0}", AKMAvgPrice);


            // Second List

            decimal BKMTotalQuan = BKM.Sum(item => item.Quantity);
            decimal BKMTotalPrice = BKM.Sum(item => item.Price);
            decimal BKMAvgPrice = BKMTotalPrice / BKM.Count();

            var AggBKM = BKM.GroupBy(e => (e.BloombergId, e.TransactionCode, e.TradeDate)).ToList();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("summary  BKM4JZ7");

            Console.WriteLine("BloombergId => {0}", AggBKM[0].Key.BloombergId);
            Console.WriteLine("TransactionCode => {0}", AggBKM[0].Key.TransactionCode);
            Console.WriteLine("TradeDate => {0}", AggBKM[0].Key.TradeDate);
            Console.WriteLine("Sum on Quantity => {0}", BKMTotalPrice);
            Console.WriteLine("Average Price => {0}", BKMAvgPrice);


            // Third List

            decimal CKMTotalQuan = CKM.Sum(item => item.Quantity);
            decimal CKMTotalPrice = CKM.Sum(item => item.Price);
            decimal CKMAvgPrice = CKMTotalPrice / CKM.Count();

            var AggCKM = CKM.GroupBy(e => (e.BloombergId, e.TransactionCode, e.TradeDate)).ToList();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("summary  CKM4JZ7");

            Console.WriteLine("BloombergId => {0}", AggCKM[0].Key.BloombergId);
            Console.WriteLine("TransactionCode => {0}", AggCKM[0].Key.TransactionCode);
            Console.WriteLine("TradeDate => {0}", AggCKM[0].Key.TradeDate);
            Console.WriteLine("Sum on Quantity => {0}", CKMTotalQuan);
            Console.WriteLine("Average Price => {0}", CKMAvgPrice);


        }
    }
}
