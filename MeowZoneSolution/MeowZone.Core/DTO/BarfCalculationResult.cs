using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	// Class for BARF calculation results
	public class BarfDietCalculationResult
	{
		public Guid CatId { get; set; }
		public string? CatName { get; set; }
		public decimal DailyFoodIntakeKg { get; set; }
		public decimal ProteinIntakeKg { get; set; }
		public decimal FatIntakeKg { get; set; }
		public decimal FibreIntakeKg { get; set; }
		public decimal OrganIntakeKg { get; set; }
	}
}
