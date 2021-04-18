using System.Collections.Generic;
using RecrutaTi.Domain.Entities.ValueObjects;

namespace RecrutaTi.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public Address Address { get; set; }
        public IList<SocialNetWorkAddress> SocialNetWorks { get; set; }
        
        public AdvertiserUser AdvertiserUser { get; set; }
    }
}