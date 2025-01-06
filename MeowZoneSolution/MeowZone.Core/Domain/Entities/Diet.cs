using MeowZone.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.DTO;

namespace MeowZone.Models
{
	/// <summary>
	/// Model for Diet
	/// </summary>
	public class Diet
	{
		public decimal DailyIntakeKg { get; set; }
		public int ProteinPercentage { get; set; }
		public int FatPercentage { get; set; }
		public int? BonePercentage { get; set; }
		public int? OrganPercentage { get; set; }
		public string? Supplements { get; set; }

	}
}