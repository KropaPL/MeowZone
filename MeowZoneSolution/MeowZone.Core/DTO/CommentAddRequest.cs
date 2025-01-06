using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class CommentAddRequest
	{
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
	}
}
