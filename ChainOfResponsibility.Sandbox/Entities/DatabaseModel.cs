using System;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox.Entities
{
    public class DatabaseModel
    {
        [Required]
        public int? ID { get; set; }

        [StringLength(30)]
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public decimal? Age { get; set; }

        public override string ToString()
        {
            return $"ID={ID} FullName={FullName} BirthDate={BirthDate} Age={Age}";
        }
    }
}
