using System.Collections.Generic;

namespace RecrutaTi.Domain.Entities
{
    public class AdvertiserUser : User
    {
        public IList<Company> Company { get; set; }
    }
}