using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace MeowZone.Core.Services
{
	public class PostsGetterService : IPostsGetterService
	{
		private readonly IPostsRepository _postsRepository;

		public PostsGetterService(IPostsRepository postsRepository)
		{
			_postsRepository = postsRepository;
		}
		public async Task<List<PostResponse>> getAllPostsbyCategoryId(Guid categoryId)
		{
			var posts = await _postsRepository.GetAllPostsAccordingToCategoryId(categoryId);
			return posts
				.Select(temp => temp.ToPostResponse()).ToList();
		}

		public async Task<List<PostResponse>> getAllPosts()
		{
			var posts = await _postsRepository.GetAllPosts();
			return posts
				.Select(temp => temp.ToPostResponse()).ToList();
		}

		public async Task<PostResponse> GetPostByPostId(Guid? postId)
		{
			if (postId == null)
			{
				return null;
			}

			Post? post = await _postsRepository.GetPostByPostId(postId.Value);

			if (post == null)
			{
				return null;
			}

			return post.ToPostResponse();
		}
	}
}
