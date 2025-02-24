using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class CountryEntity
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string CountryName { get; set; }
    }
}
