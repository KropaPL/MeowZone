using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;

namespace MeowZone.Core.ServiceContracts
{
	public interface IPostsGetterService
	{
		Task<List<PostResponse>> getAllPostsbyCategoryId(Guid categoryId);
		Task<List<PostResponse>> getAllPosts();
		Task<PostResponse> GetPostByPostId(Guid? postId);
	}
}
