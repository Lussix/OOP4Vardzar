namespace OOP4Vardzar
{
    internal class Customer
    {
        public int CardNumber { get; }
        public int Money { get; private set; }
        public int ItemsBought { get; private set; }
        public int MoneySpent { get; private set; }

        public Customer(int cardNumber, int money)
        {
            CardNumber = cardNumber;
            Money = money;
        }

        public bool CanAfford(Product product)
        {
            return Money >= product.Price;
        }

        public void Pay(Product product)
        {
            Money = Money - product.Price;
            MoneySpent = MoneySpent + product.Price;
            ItemsBought++;
        }
    }
}