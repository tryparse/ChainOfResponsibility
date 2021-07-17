using System;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Entities
{
    public class Entity
    {
        public int? ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public int? Amount { get; set; }
    }
}
