using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
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

		public async Task<bool> DeleteComment(Guid commentId)
		{
			if (commentId == null)
			{
				throw new ArgumentNullException(nameof(commentId));
			}

			Comment? comment = await _commentRepository.GetCommentByCommentId(commentId);
			if (comment == null)
			{
				return false;
			}

			await _commentRepository.DeleteComment(commentId);

			return true;
		}
	}
}
