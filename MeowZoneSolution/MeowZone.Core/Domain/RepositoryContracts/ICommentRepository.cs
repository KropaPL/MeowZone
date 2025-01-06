using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.Domain.RepositoryContracts
{
	public interface ICommentRepository
	{
		/// <summary>
		/// Adds Comment object to the database
		/// </summary>
		/// <param name="comment">Comment object to add</param>
		/// <returns>Returns the comment object after adding it to the database</returns>
		Task<Comment> AddComment(Comment comment);

		/// <summary>
		///  Updates Comment object in the database
		/// </summary>
		/// <param name="comment">Comment object to update</param>
		/// <returns></returns>
		Task<Comment> UpdateComment(Comment comment);

		/// <summary>
		/// Deletes Comment from the database based on given Id (guid) from database
		/// </summary>
		/// <param name="id">Comment Id to delete</param>
		/// <returns>Returns true id the deletion is successful; otherwise, return false.</returns>
		Task<bool> DeleteComment(Guid id);

		/// <summary>
		/// Gets comment based on given Id (guid) from database
		/// </summary>
		/// <param name="commentId">CommentId to search</param>
		/// <returns>Returns comment based on given id</returns>
		Task<Comment> GetCommentByCommentId(Guid commentId);

		/// <summary>
		/// Gets List of Comments based on PostId
		/// </summary>
		/// <param name="postId">PostId to search</param>
		/// <returns>Returns List of comments from one post</returns>
		Task<List<Comment>> GetCommentsByPostId(Guid postId);

	}
}
