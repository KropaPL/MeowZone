using MeowZone.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICommentGetterService
	{
		Task<List<Comment>> getAllCommentsbyPostId(Guid categoryId);
		Task<List<CommentResponse>> getAllComments();
		Task<CommentResponse> GetCommentByCommentId(Guid? commentId);
	}
}
