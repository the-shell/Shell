using System;

namespace Shell.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int BusinessId { get; set; }
        public Guid UserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateCreated { get; set; }

        public string DisplayImage { get; set; }
    }
}