using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class CommentResponse
	{
		public Guid Id { get; set; }
		public string CommentContent { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
