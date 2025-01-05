using MeowZone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;

namespace MeowZone.Core.Domain.RepositoryContracts
{
	internal interface ICategoryRepository
	{
		/// <summary>
		/// Adds category to the database
		/// </summary>
		/// <param name="category">Category object to add</param>
		/// <returns>Returns the category object after adding it to the database</returns>
		Task<Category> AddCategory(Category category);

		/// <summary>
		/// Updates a category object in the database
		/// </summary>
		/// <param name="category">Category object to update</param>
		/// <returns>Returns the updated category object</returns>
		Task<Category> UpdateCategory(Category category);


		/// <summary>
		/// Deletes a category based on the category id 
		/// </summary>
		/// <param name="categoryId">CategoryID (guid) to delete</param>
		/// <returns>Returns true if the deletion is successful; otherwise, return false.</returns>
		Task<Category> DeleteCategory(Guid categoryId);


		/// <summary>
		/// Returns a category object based on the given category id 
		/// </summary>
		/// <param name="categoryId">CategoryID (guid) to search</param>
		/// <returns>A category object or null</returns>
		Task<Category> GetCategoryByCategoryId(Guid categoryId);

		/// <summary>
		/// Returns all categories
		/// </summary>
		/// <returns>Returns all categories stored in the database</returns>
		Task<List<Category>> GetAllCategories();
	}
}
