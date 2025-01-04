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

		Task<Category> AddCategory(Category category);


		Task<Cat> UpdateCategory(Cat cat);

		Task<Cat> DeleteCategory(Guid catID);

		Task<Cat> GetCatByCategoryID(Guid catID);


		Task<List<Cat>> GetAllCategories(Guid UserID);
	}
}
