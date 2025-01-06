using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Infrastructure.DbContext;
using MeowZone.Models;
using Microsoft.EntityFrameworkCore;

namespace MeowZone.Infrastructure.Repositories
{
	public class CommentsRepository : ICommentRepository
	{
		private readonly ApplicationDbContext _db;

		public CommentsRepository(ApplicationDbContext db)
		{
			_db = db;
		}

		public async Task<Comment> AddComment(Comment comment)
		{
			_db.Comments.Add(comment);
			await _db.SaveChangesAsync();

			return comment;
		}

		public async Task<Comment> UpdateComment(Comment comment)
		{
			Comment? matchingComment = await _db.Comments.FirstOrDefaultAsync(temp => temp.Id == comment.Id);

			if (matchingComment == null)
				return comment;

			matchingComment.Content = comment.Content;

			int countUpdated = await _db.SaveChangesAsync();

			return matchingComment;
		}

		public async Task<bool> DeleteComment(Guid id)
		{
			_db.Comments.RemoveRange(_db.Comments.Where(temp => temp.Id == id));
			int rowsDeleted = await _db.SaveChangesAsync();

			return rowsDeleted > 0;
		}

		public async Task<Comment> GetCommentByCommentId(Guid commentId)
		{
			return await _db.Comments.FirstOrDefaultAsync(temp => temp.Id == commentId);
		}

		public async Task<List<Comment>> GetCommentsByPostId(Guid postId)
		{
			return await _db.Comments.Where(temp => temp.PostId == postId).ToListAsync();
		}
	}
}
