using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.IdentityEntities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using Microsoft.AspNetCore.Identity;

namespace MeowZone.Core.Services
{
	public class PostsAdderService : IPostsAdderService
	{
		private readonly IPostsRepository _postsRepository;
		private readonly UserManager<ApplicationUser> _userManager;

		public PostsAdderService(IPostsRepository postsRepository)
		{
			_postsRepository = postsRepository;
		}
		public async Task<PostResponse> AddPost(PostAddRequest? postAddRequest, Guid authorId, Guid categoryId)
		{
			if (postAddRequest == null)
			{
				throw new ArgumentNullException(nameof(postAddRequest));
			}

			Post post = postAddRequest.ToPost();

			post.Id = Guid.NewGuid();
			post.AuthorId = authorId;
			post.CategoryId = categoryId;
			post.CreatedAt = DateTime.UtcNow;

			await _postsRepository.AddPost(post);


			return post.ToPostResponse();
		}
	}
}
