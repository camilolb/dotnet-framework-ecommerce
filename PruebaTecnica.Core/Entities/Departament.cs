#nullable disable

namespace PruebaTecnica.Core.Entities
{
    public partial class Departament : BaseEntity
    {
        public string Number { get; set; }
        public int OwerId { get; set; }
        public int BuildId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }

        public virtual Owner Ower { get; set; }
        public virtual Build Build { get; set; }
    }
}
