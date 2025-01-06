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
	public class CommentUpdaterService : ICommentUpdaterService
	{
		private readonly ICommentRepository _commentRepository;

		public CommentUpdaterService(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}
		public async Task<CommentResponse> UpdatePost(CommentUpdateRequest? commentUpdateRequest)
		{
			if (commentUpdateRequest == null)
			{
				throw new ArgumentNullException(nameof(commentUpdateRequest));
			}

			Comment? matchingComment = await _commentRepository.GetCommentByCommentId(commentUpdateRequest.Id);

			if (matchingComment == null)
			{
				throw new ArgumentNullException(nameof(commentUpdateRequest));
			}

			matchingComment.CommentContent = commentUpdateRequest.CommentContent;

			await _commentRepository.UpdateComment(matchingComment);

			return matchingComment.ToCommentResponse();
		}
	}
}
