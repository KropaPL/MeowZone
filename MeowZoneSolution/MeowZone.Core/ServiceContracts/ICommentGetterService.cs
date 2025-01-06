using MeowZone.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICommentGetterService
	{
		Task<List<CommentResponse>> getAllCommentbyPostId(Guid categoryId);
		Task<List<CommentResponse>> getAllComments();
		Task<CommentResponse> GetCommentByCommentId(Guid? commentId);
	}
}
