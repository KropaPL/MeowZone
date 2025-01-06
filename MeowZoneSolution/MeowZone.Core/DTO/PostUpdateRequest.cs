using MeowZone.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class PostUpdateRequest
	{
		[Required]
		public Guid Id { get; set; }

		[Required]
		[StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
		public string Title { get; set; }

		[Required]
		public string Content { get; set; }

		public Post ToPost()
		{
			return new Post()
			{
				Id = Id,
				Title = Title,
				Content = Content,
			};
		}
	}
}
