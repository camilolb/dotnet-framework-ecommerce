using System;
namespace PruebaTecnica.Core.Entities
{
    public abstract class BaseEntity
    {

        public int Id { get; set; }
        public DateTime? Create { get; set; }
        public DateTime? Modify { get; set; }
    }
}
