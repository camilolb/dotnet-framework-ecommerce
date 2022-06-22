using System;
using System.Collections.Generic;

#nullable disable

namespace GenerateModel.Model
{
    public partial class Product
    {
        public Product()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
