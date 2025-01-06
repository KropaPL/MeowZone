using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.ServiceContracts;

namespace MeowZone.Core.Services
{
	public class CommentDeleterService : ICommentDeleterService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentDeleterService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public Task<bool> DeleteComment(Guid postId)
		{
			throw new NotImplementedException();
		}
	}
}
