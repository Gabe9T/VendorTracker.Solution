using System.Collections.Generic;

namespace VendorTracker.Models
{
    public class Vendor
    {
        private static int _idCounter = 1;

        public Vendor(string name, string description)
        {
            Name = name;
            Description = description;
            Orders = new List<Order>();
            Id = _idCounter++;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
        public int Id { get; }
    }
}