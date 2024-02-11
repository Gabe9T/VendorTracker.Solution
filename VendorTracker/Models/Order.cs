namespace VendorTracker.Models
{
    public class Order
    {
        private static int _idCounter = 1;

        public Order(string title, string description, double price, DateTime date)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
            Id = _idCounter++;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; }

        public void UpdateOrder(string title, string description, double price, DateTime date)
        {
            Title = title;
            Description = description;
            Price = price;
            Date = date;
        }
    }
}