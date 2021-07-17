using System;

namespace ChainOfResponsibility.Sandbox.Entities
{
    public class DatabaseModel
    {
        public int? ID { get; set; }

        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal? Amount { get; set; }

        public override string ToString()
        {
            return $"ID={ID} FullName={FullName} BirthDate={BirthDate} Amount={Amount}";
        }
    }
}
