using System;
namespace DellTest.Models
{
    public class Contact : Entity<int>, IContactSummary
    {
        public string Name { get; set; }
        public string Company { get; set; }
    }
}
