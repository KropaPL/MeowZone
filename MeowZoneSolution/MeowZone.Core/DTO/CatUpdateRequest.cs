using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Models;

namespace MeowZone.Core.DTO
{
	public class CatUpdateRequest
	{
		[Required(ErrorMessage = "Cat ID can't be blank")]
		public Guid Id { get; set; }

		[Required(ErrorMessage = "Name can't be blank")]
		public string Name { get; set; }

		[Range(0.1, 50.0)]
		public decimal? Weight { get; set; }

		[Range(0, 30)]
		public int? Age { get; set; }

		[StringLength(50)]
		public string? Breed { get; set; }

		[StringLength(30)]
		public string? Color { get; set; }
		public GenderOptions? Gender { get; set; }

		public Cat ToCat()
		{
			return new Cat()
			{
				Name = Name,
				Weight = Weight,
				Age = Age,
				Breed = Breed,
				Color = Color,
				Gender = Gender,
			};
		}
	}
}
