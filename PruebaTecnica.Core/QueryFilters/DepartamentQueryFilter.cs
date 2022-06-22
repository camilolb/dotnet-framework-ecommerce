using System;
namespace PruebaTecnica.Core.QueryFilters
{
    public class DepartamentQueryFilter
    {
        public string Number { get; set; }
        public string Owner { get; set; }
        public string Build { get; set; }
        public decimal? Price { get; set; }
    }
}
