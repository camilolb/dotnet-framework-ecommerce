using System;
using System.Collections.Generic;

#nullable disable

namespace generate.Model
{
    public partial class Owner
    {
        public Owner()
        {
            Departaments = new HashSet<Departament>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Departament> Departaments { get; set; }
    }
}
