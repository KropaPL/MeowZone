using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.DTO
{
	public class CommentAddRequest
	{
		public string CommentContent { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
		public Guid PostId { get; set; }

		public Comment ToComment()
		{
			return new Comment()
			{
				CommentContent = CommentContent,
				CreatedAt = CreatedAt,
				PostId = PostId
			};
		}
	}
}
