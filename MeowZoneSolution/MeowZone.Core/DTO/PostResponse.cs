using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class PostResponse
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public string Summary { get; set; }
		public DateTime CreatedAt { get; set; }
		public Guid AuthorId { get; set; }
		public string AuthorName { get; set; }
		public Guid CategoryId { get; set; }
		public string CategoryName { get; set; }
		public int ViewCount { get; set; }
		public bool IsPublished { get; set; }
	}
}
