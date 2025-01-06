using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class CategoryUpdateRequest
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		[StringLength(50, ErrorMessage = "Category name cannot exceed 50 characters")]
		public string Name { get; set; }

		[StringLength(800)]
		public string Description { get; set; }
	}
}
