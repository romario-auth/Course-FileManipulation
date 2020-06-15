using System.Collections.Generic;
using System.Globalization;

namespace FileOrder.Entities
{
    class Order
    {
        public List<string> Request{get; set;}
        public List<OrderItem> Item = new List<OrderItem>();

        public Order(List<string> request)
        {
            Request = request;
        }

        public void ReadOrderItem()
        {

            foreach (string orderItems in Request)
            {
                string[] orderItem = (orderItems.ToString().Split(","));
                string name = orderItem[0];
                double price = double.Parse(orderItem[1], CultureInfo.InvariantCulture);
                int quantity = int.Parse(orderItem[2]);

               Item.Add(new OrderItem(new Product(name, price), price, quantity));
            }
        }
    }

}