using System;

namespace Grocer.Models
{
    public class Item
    {
        public Guid ItemID { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
