using System;
using System.ComponentModel.DataAnnotations;

namespace ChainOfResponsibility.Sandbox
{
    class DatabaseModel
    {
        [Required]
        public int? ID { get; set; }
        
        [StringLength(20)]
        public string FullName { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        
        public decimal? Amount { get; set; }
    }
}
