using MeowZone.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;

namespace MeowZone.Models
{
	/// <summary>
	/// Domain Model for Cat
	/// </summary>
	public class Cat
    {
        [Key]
        public Guid Id { get; set; }

		[Required(ErrorMessage = "Name is required")]
		[MinLength(1, ErrorMessage = "Name cannot be empty")]
		[StringLength(100)]
		public string Name { get; set; }

		[Range(0.1, 50.0)]
        public decimal? Weight { get; set; }

        [Range(0, 30)]
        public int? Age { get; set; }

        [StringLength(50)]
        public string? Breed { get; set; }

        [StringLength(30)]
        public string? Color { get; set; }

        [ForeignKey("Owner")]
        public Guid OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
		public GenderOptions? Gender { get; set; }

		public CatResponse ToCatResponse()
		{
			return new CatResponse()
			{
				Age = this.Age,
				Breed = this.Breed,
				Gender = this.Gender,
				Name = this.Name,
				Weight = this.Weight,
				Id = this.Id,
				Color = this.Color
			};
		}

	}
}
