using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CompanyEntity
    {
        [Key] // Marks this property as the primary key
        public int CompanyId { get; set; }

        [Required] // Ensures the company name is provided
        [MaxLength(100)] // Limits the length of the company name
        public string CompanyName { get; set; }
    }
}
