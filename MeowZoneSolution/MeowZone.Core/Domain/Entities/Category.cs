using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;

namespace MeowZone.Core.Domain.Entities
{
	public class Category
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
		public string Name { get; set; }

		[StringLength(800)]
		public string Description { get; set; }

		public CategoryResponse ToCategoryResponse()
		{
			return new CategoryResponse()
			{
				Id = Id,
				Name = Name,
				Description = Description
			};
		}

	}
}
