using RecrutaTi.Domain.Entities.ValueObjects;

namespace RecrutaTi.Domain.Entities
{
    public class User : Entity
    {
        public Name Name { get; set; }
        public string Email { get; set; }
        public string TelephoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}