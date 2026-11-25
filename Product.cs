namespace OOP4Vardzar
{
    internal class Product
    {
        public string Name { get; }
        public int Price { get; }
        public int Quantity { get; set; }

        public Product(string name, int price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}