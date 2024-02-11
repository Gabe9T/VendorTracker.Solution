namespace VendorTracker.Models
{
    public class Vendor
    {
        private static int _idCounter = 1;
        private static List<Vendor> _allVendors = new List<Vendor>();

        public Vendor(string name, string description)
        {
            Name = name;
            Description = description;
            Orders = new List<Order>();
            Id = _idCounter++;
            _allVendors.Add(this);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Order> Orders { get; set; }
        public int Id { get; }

        public static List<Vendor> GetAll()
        {
            return _allVendors;
        }

        public static void Add(Vendor vendor)
        {
            _allVendors.Add(vendor);
        }

        public static Vendor Find(int id)
        {
            return _allVendors.FirstOrDefault(v => v.Id == id);
        }
        
    }
}