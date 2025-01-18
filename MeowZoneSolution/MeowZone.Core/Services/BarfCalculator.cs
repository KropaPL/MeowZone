using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using System;
using System.Threading.Tasks;

namespace MeowZone.Core.Services
{
	public class BarfCalculator : IBarfCalculator
	{

		private const int ProteinPercentage = 50; // 50% protein
		private const int FatPercentage = 30; // 30% fat
		private const int BonePercentage = 10; // 10% bone
		private const int OrganPercentage = 10; // 10% organ

		public async Task<BarfDietCalculationResult> CalculateBarf(CatResponse cat)
		{

			decimal dailyFoodIntakeKg = CalculateRawFoodIntake(cat.Weight.Value);


			decimal proteinIntakeKg = dailyFoodIntakeKg * ProteinPercentage / 100;
			decimal fatIntakeKg = dailyFoodIntakeKg * FatPercentage / 100;
			decimal boneIntakeKg = dailyFoodIntakeKg * BonePercentage / 100;
			decimal organIntakeKg = dailyFoodIntakeKg * OrganPercentage / 100;

			return new BarfDietCalculationResult
			{
				CatId = cat.Id,
				CatName = cat.Name,
				DailyFoodIntakeKg = Math.Round(dailyFoodIntakeKg, 2),
				ProteinIntakeKg = Math.Round(proteinIntakeKg, 2),
				FatIntakeKg = Math.Round(fatIntakeKg, 2),
				FibreIntakeKg = Math.Round(boneIntakeKg, 2),
				OrganIntakeKg = Math.Round(organIntakeKg, 2),
			};

		}

		private decimal CalculateRawFoodIntake(decimal catWeight)
		{
			decimal foodIntakePercentage = 0.06m; 
			return catWeight * foodIntakePercentage;
		}
	}
}
