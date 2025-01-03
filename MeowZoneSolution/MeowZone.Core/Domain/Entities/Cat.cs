using MeowZone.Enums;
using System.ComponentModel.DataAnnotations;

namespace MeowZone.Models
{
    public class Cat
    {
        /// <summary>
        /// Domain Model for Cat
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.1, 50.0)]
        public decimal Weight { get; set; }

        [Range(0, 30)]
        public int Age { get; set; }

        [StringLength(50)]
        public string? Breed { get; set; }

        [StringLength(30)]
        public string? Color { get; set; }

        public GenderOptions? Gender { get; set; }
    }
}
