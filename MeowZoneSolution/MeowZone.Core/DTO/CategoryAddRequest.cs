using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class CategoryAddRequest
	{
		public string Name { get; set; }
		public string Description { get; set; }
	}
}
