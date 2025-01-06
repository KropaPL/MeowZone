using System;
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
		public string Title { get; set; }
		public string Content { get; set; }
		public Guid CategoryId { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


		public Post ToPost()
		{
			return new Post()
			{
				Title = Title,
				Content = Content,
				CategoryId = CategoryId,
			};
		}
	}
}
