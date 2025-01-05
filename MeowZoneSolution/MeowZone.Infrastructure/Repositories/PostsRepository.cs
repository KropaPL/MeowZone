using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace MeowZone.Infrastructure.Repositories
{
	public class PostsRepository : IPostRepository
	{
		private readonly ApplicationDbContext _db;

		public PostsRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<Post> AddPost(Post post)
		{
			_db.Posts.Add(post);

			await _db.SaveChangesAsync();

			return post;
		}

		public async Task<Post> UpdatePost(Post post)
		{
			Post? matchingPost = await _db.Posts.FirstOrDefaultAsync(temp => temp.Id == post.Id);

			if (matchingPost == null)
			{
				return null;
			}

			matchingPost.Title = post.Title;
			matchingPost.Content = post.Content;
			matchingPost.Summary = post.Summary;
			matchingPost.IsPublished = post.IsPublished;
			matchingPost.CategoryId = post.CategoryId;

			_db.Posts.Update(matchingPost);
			await _db.SaveChangesAsync();

			return matchingPost;
		}


		public async Task<bool> DeletePost(Guid postId)
		{
			_db.Posts.RemoveRange(_db.Posts.Where(temp => temp.Id == postId));
			int rowsDeleted = await _db.SaveChangesAsync();

			return rowsDeleted > 0;
		}

		public async Task<List<Post>> GetAllPosts()
		{
			return await _db.Posts.Include("Post").ToListAsync();
		}

		public async Task<Post?> GetPostById(Guid postId)
		{
			return await _db.Posts.Include("Post")
				.FirstOrDefaultAsync(temp => temp.Id == postId);
		}
	}
}
