using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;

namespace MeowZone.Core.Services
{
	public class CommentAdderService : ICommentAdderService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentAdderService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}



		public async Task<CommentResponse> AddComment(CommentAddRequest? commentAddRequest, Guid authorId, Guid postId)
		{
			if (commentAddRequest == null)
			{
				throw new ArgumentNullException(nameof(commentAddRequest));
			}

			Comment comment = commentAddRequest.ToComment();

			comment.Id = Guid.NewGuid();
			comment.AuthorId = authorId;
			comment.PostId = postId;
			comment.CreatedAt = DateTime.UtcNow;

			await _commentRepository.AddComment(comment);

			return comment.ToCommentResponse();
		}
	}
}
