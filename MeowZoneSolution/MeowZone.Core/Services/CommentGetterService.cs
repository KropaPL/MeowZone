using MeowZone.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
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

		public async Task<List<Comment>> getAllCommentsbyPostId(Guid categoryId)
		{
			var comments = await _commentRepository.GetCommentsByPostId(categoryId);
			return comments;
		}

		public Task<List<CommentResponse>> getAllComments()
		{
			throw new NotImplementedException();
		}


		public async Task<CommentResponse> GetCommentByCommentId(Guid? commentId)
		{
			if (commentId == null)
			{
				return null;
			}

			Comment? comment = await _commentRepository.GetCommentByCommentId(commentId.Value);

			if (comment == null)
			{
				return null;
			}

			return comment.ToCommentResponse();
		}
	}
}
