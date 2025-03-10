﻿using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Models;

namespace MeowZone.Core.DTO
{
	public class CatAddRequest
	{

		public string Name { get; set; }
		public decimal? Weight { get; set; }
		public int? Age { get; set; }
		public string? Breed { get; set; }
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
				Gender = Gender
			};
		}
	}
}
