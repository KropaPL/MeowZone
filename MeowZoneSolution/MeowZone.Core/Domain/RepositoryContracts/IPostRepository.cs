using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.Domain.RepositoryContracts
{
	public interface IPostRepository
	{
		/// <summary>
		/// Adds a post object to the database
		/// </summary>
		/// <param name="post">Post object to add</param>
		/// <returns>Returns the post object after adding it to the database</returns>
		Task<Post> AddPost(Post post);

		/// <summary>
		/// Updates a post object in the database
		/// </summary>
		/// <param name="post">Post object to update</param>
		/// <returns></returns>
		Task<Post> UpdatePost(Post post);

		/// <summary>
		/// Deletes a post object based on the post id
		/// </summary>
		/// <param name="postId">PostID (guid) to delete</param>
		/// <returns>Return true id the deletion is successful; otherwise, return false.</returns>
		Task DeletePost(Guid postId);
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		Task<List<Post>> GetAllPosts();

		/// <summary>
		/// 
		/// </summary>
		/// <param name="postId"></param>
		/// <returns></returns>
		Task<Post> GetPostById(Guid postId);
	}
}
