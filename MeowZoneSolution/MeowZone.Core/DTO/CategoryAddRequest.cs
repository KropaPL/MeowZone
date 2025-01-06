using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.DTO
{
	public class CategoryAddRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public Category ToCategory()
		{
			return new Category()
			{
				Name = Name,
				Description = Description
			};
		}
	}
}
