using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Models;

namespace MeowZone.Core.ServiceContracts
{
	public interface IBarfCalculator
	{
		/// <summary>
		/// Calculates barf diet for a cat
		/// </summary>
		/// <param name="cat"></param>
		/// <returns></returns>
		public Task<BarfDietCalculationResult> CalculateBarf(CatResponse cat);
	}
}
