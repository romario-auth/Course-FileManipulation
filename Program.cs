using System;
using System.Collections.Generic;
using FileOrder.Entities;
using FileOrder.Entities.DomainFile;

namespace FileOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            try{
                Console.WriteLine("Get Summary");
                Console.Write("Enter path order: ");
                string path = Console.ReadLine();
                
                Console.Write("Enter file Order: ");
                string orderFile = Console.ReadLine();

                Console.Write("Enter file Summary: ");
                string summaryFile = Console.ReadLine();

                UseFile files = new UseFile(path, orderFile, summaryFile);
                List<string> dataOrder = files.ReadData();

                Order order = new Order(dataOrder);/*Create a Order*/
                order.ReadOrderItem(); /*Create OrderItem*/
                files.WriteData(order.Item); /*Store Order*/
            } catch(Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
