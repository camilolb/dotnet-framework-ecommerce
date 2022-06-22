using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class Build
    {
        public Build()
        {
            Departaments = new HashSet<Departament>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Tower { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }

        public virtual ICollection<Departament> Departaments { get; set; }
    }
}
