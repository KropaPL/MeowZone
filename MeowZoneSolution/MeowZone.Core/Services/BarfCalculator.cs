using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using MeowZone.Models;

namespace MeowZone.Core.Services
{
	public class BarfCalculator : IBarfCalculator
	{
		private readonly Diet _diet = new Diet();

		public async Task<BarfDietCalculationResult> CalculateBarf(CatResponse cat)
		{

			// Calculate the total raw food intake (as a percentage of cat's weight)
			decimal dailyFoodIntakeKg = CalculateRawFoodIntake(cat.Weight.Value);

			// Calculate the individual components (protein, fat, bone, etc.)
			decimal proteinIntakeKg = dailyFoodIntakeKg * _diet.ProteinPercentage / 100;
			decimal fatIntakeKg = dailyFoodIntakeKg * _diet.FatPercentage / 100;
			decimal boneIntakeKg = _diet.BonePercentage.HasValue ? dailyFoodIntakeKg * _diet.BonePercentage.Value / 100 : 0;
			decimal organIntakeKg = _diet.OrganPercentage.HasValue ? dailyFoodIntakeKg * _diet.OrganPercentage.Value / 100 : 0;

			// Supplements if any (not included in the raw weight calculation)
			string supplements = _diet.Supplements ?? "No supplements specified.";

			// Return the result
			return new BarfDietCalculationResult
			{
				CatId = cat.Id,
				CatName = cat.Name,
				DailyFoodIntakeKg = dailyFoodIntakeKg,
				ProteinIntakeKg = proteinIntakeKg,
				FatIntakeKg = fatIntakeKg,
				BoneIntakeKg = boneIntakeKg,
				OrganIntakeKg = organIntakeKg,
				Supplements = supplements
			};
		}

		// Method to calculate raw food intake based on the cat's weight
		private decimal CalculateRawFoodIntake(decimal catWeight)
		{
			// We assume 2-3% of the cat's body weight is used for daily food intake
			decimal foodIntakePercentage = 0.03m; // for example, we use 3% of the weight for raw food
			return catWeight * foodIntakePercentage;
		}
	}
}
}
