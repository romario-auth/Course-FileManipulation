using System.Globalization;

namespace FileOrder.Entities
{
    class OrderItem
    {
        public Product Product {get; set;}
        public double Price {get; private set;}
        public int Quantity {get; private set;}

        public OrderItem()
        {

        }

        public OrderItem(Product product, double price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public double SubToTal()
        {
            return Price * Quantity;
        }

        public override string ToString()
        {
            return Product.Name + ", " + SubToTal().ToString("F2", CultureInfo.InvariantCulture);
        }

    }
}