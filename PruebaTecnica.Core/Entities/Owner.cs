
using System;
using System.Collections.Generic;

namespace PruebaTecnica.Core.Entities
{
    public partial class Owner : BaseEntity
    {
        public Owner()
        {
            Departaments = new HashSet<Departament>();
        }

        public string FullName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Departament> Departaments { get; set; }
    }
}
