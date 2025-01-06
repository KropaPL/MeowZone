using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		public Task<CommentResponse> UpdatePost(CommentUpdateResponse? commentUpdateResponse)
		{
			throw new NotImplementedException();
		}
	}
}
