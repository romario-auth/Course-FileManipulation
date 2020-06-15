using System;
using System.IO;
using System.Collections.Generic;

namespace FileOrder.Entities.DomainFile
{
    class UseFile
    {
        public string Path{get; private set;}
        public string FileIn{get; private set;}
        public string FileOut{get; private set;}

        public UseFile()
        {

        }

        public UseFile(string path, string fileIn, string fileOut)
        {
            Path = path;        // /tmp/Order/
            FileIn = fileIn;    // Order.csv
            FileOut = fileOut;  // Summary.csv
        }

        public List<string> ReadData()
        {
            using(FileStream fs = new FileStream(Path+FileIn, FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    List<string> ordemItem = new List<string>();
                    while (sr.Peek() >= 0)
                    {
                        
                        ordemItem.Add(sr.ReadLine());
                    }

                    return ordemItem;
                }
            }
        }

        public void WriteData(List<OrderItem> orderItem)
        {
            try{
                using (StreamWriter sw = File.AppendText(Path+FileOut))
                {
                    foreach(OrderItem line in orderItem)
                    {
                        sw.WriteLine(line.ToString());
                    }

                }
            } catch (IOException e)
            {
                Console.WriteLine("Erro Store Data " + e.Message);
            }
        }
    }
}