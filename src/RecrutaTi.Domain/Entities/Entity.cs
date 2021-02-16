using System;

namespace RecrutaTi.Domain.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}