using MeowZone.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Core.Domain.RepositoryContracts;

namespace MeowZone.Core.Services
{
	public class CommentGetterService : ICommentGetterService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentGetterService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public Task<List<CommentResponse>> getAllCommentbyPostId(Guid categoryId)
		{
			throw new NotImplementedException();
		}

		public Task<List<CommentResponse>> getAllComments()
		{
			throw new NotImplementedException();
		}

		public Task<CommentResponse> GetCommentByCommentId(Guid? postId)
		{
			throw new NotImplementedException();
		}
	}
}
