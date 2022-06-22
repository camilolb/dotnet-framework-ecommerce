using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class Departament
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
        public int OwerId { get; set; }
        public int BuildId { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }

        public virtual Build Build { get; set; }
        public virtual Owner Ower { get; set; }
    }
}
