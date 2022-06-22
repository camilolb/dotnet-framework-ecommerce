using System;
using System.Collections.Generic;

#nullable disable

namespace PruebaTecnica.Core.Entities
{
    public partial class Build : BaseEntity
    {
        public Build()
        {
            Departaments = new HashSet<Departament>();
        }

        public string Name { get; set; }
        public string Address { get; set; }
        public string Tower { get; set; }


        public virtual ICollection<Departament> Departaments { get; set; }
    }
}
