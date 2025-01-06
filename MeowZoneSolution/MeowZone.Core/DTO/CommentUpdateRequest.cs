using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.DTO
{
	public class CommentUpdateRequest
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
	}
}
