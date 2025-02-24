using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ContactEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ContactName { get; set; }

        public int CompanyId { get; set; }

        [ForeignKey("CompanyId")]
        public CompanyEntity Company { get; set; }

        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public CountryEntity Country { get; set; }
    }
}
