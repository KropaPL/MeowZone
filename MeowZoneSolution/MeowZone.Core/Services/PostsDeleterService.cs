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
	public class PostsDeleterService : IPostsDeleterService
	{
		private readonly IPostsRepository _postsRepository;

		public PostsDeleterService(IPostsRepository postsRepository)
		{
			_postsRepository = postsRepository;
		}
		public async Task<bool> DeletePost(Guid postId)
		{
			if (postId == null)
			{
				throw new ArgumentNullException(nameof(postId));
			}

			Post? post = await _postsRepository.GetPostByPostId(postId);
			if (post == null)
			{
				return false;
			}

			await _postsRepository.DeletePost(postId);

			return true;
		}
	}
}
