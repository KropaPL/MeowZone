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
	public class PostsUpdaterService : IPostsUpdaterService
	{
		private readonly IPostsRepository _postsRepository;

		public PostsUpdaterService(IPostsRepository postsRepository)
		{
			_postsRepository = postsRepository;
		}
		public async Task<PostResponse> UpdatePost(PostUpdateRequest? postUpdateRequest)
		{
			if (postUpdateRequest == null)
			{
				throw new ArgumentNullException(nameof(postUpdateRequest));
			}

			Post? matchingPost = await _postsRepository.GetPostByPostId(postUpdateRequest.Id);

			if (matchingPost == null)
			{
				throw new ArgumentNullException(nameof(postUpdateRequest));
			}

			matchingPost.Title = postUpdateRequest.Title;
			matchingPost.Content = postUpdateRequest.Content;

			await _postsRepository.UpdatePost(matchingPost);

			return matchingPost.ToPostResponse();
		}
	}
}
