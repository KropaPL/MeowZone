﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;

namespace MeowZone.Core.Domain.Entities
{
	public class Comment
	{
		[Key]
		public Guid Id { get; set; }
		[Required]
		public string CommentContent { get; set; }
		[ForeignKey("Author")]
		public Guid AuthorId { get; set; }
		public string? AuthorName { get; set; }

		[ForeignKey("PostId")]
		public Guid PostId { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public CommentResponse ToCommentResponse()
		{
			return new CommentResponse()
			{
				CommentContent = CommentContent,
				CreatedAt = CreatedAt,
				Id = Id
			};
		}
	}
}
