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
	public class CategoriesRepository : ICategoriesRepository
	{
		private readonly ApplicationDbContext _db;

		public CategoriesRepository(ApplicationDbContext db)
		{
			_db = db;
		}


		public async Task<Category> AddCategory(Category category)
		{
			_db.Categories.Add(category);
			await _db.SaveChangesAsync();
			return category;
		}

		public async Task<Category> UpdateCategory(Category category)
		{
			Category? matchingCategory = await _db.Categories.FirstOrDefaultAsync(temp => temp.Id == category.Id);

			if (matchingCategory == null) return null;

			matchingCategory.Name = category.Name;
			matchingCategory.Description = category.Description;

			int countUpdated = await _db.SaveChangesAsync();

			return matchingCategory;
		}

		public async Task<bool> DeleteCategory(Guid categoryId)
		{
			_db.Categories.RemoveRange(_db.Categories.Where(temp => temp.Id == categoryId));
			int rowsDeleted = await _db.SaveChangesAsync();

			return rowsDeleted > 0;
		}

		public async Task<Category> GetCategoryByCategoryId(Guid categoryId)
		{
			return await _db.Categories.FirstOrDefaultAsync(temp => temp.Id == categoryId);
		}

		public async Task<List<Category>> GetAllCategories()
		{
			return await _db.Categories.ToListAsync();
		}
	}
}
