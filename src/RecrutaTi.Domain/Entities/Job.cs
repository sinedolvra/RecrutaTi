using System.Collections.Generic;

namespace RecrutaTi.Domain.Entities
{
    public class Job : Entity
    {
        public string Description { get; set; }
        public IList<string> SkillsRequired { get; set; }
        public IList<string> Knowledge { get; set; }
        public IList<string> Benefits { get; set; }
        public string ReferenceAddress { get; set; }
        public string SalaryOffer { get; set; }
        public int YearsExperience { get; set; }
        public string LevelExperience { get; set; }
        public int WorkHours { get; set; }
        public Company Company { get; set; }
        public int Quantity { get; set; }
        public string Category { get; set; }
    }
}