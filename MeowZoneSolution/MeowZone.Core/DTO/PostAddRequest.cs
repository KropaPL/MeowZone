﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.DTO
{
	public class PostAddRequest
	{
		[Required]
		[StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
		public string Title { get; set; }

		[Required]
		[MinLength(20, ErrorMessage = "Content must be at least 20 characters long.")]
		public string Content { get; set; }

		[Required]
		public Guid CategoryId { get; set; }

		[StringLength(500, ErrorMessage = "Summary cannot exceed 500 characters.")]
		public string Summary { get; set; }

		public bool IsPublished { get; set; }

		public Post ToPost()
		{
			return new Post()
			{
				Title = Title,
				Content = Content,
				CategoryId = CategoryId,
				Summary = Summary,
				IsPublished = IsPublished
			};
		}
	}
}
