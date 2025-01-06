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
	public class CategoriesGetterService : ICategoryGetterService
	{
		private readonly ICategoriesRepository _categoriesRepository;

		public CategoriesGetterService(ICategoriesRepository categoriesRepository)
		{
			_categoriesRepository = categoriesRepository;
		}

		public async Task<List<CategoryResponse>> GetAllCategories()
		{
			var categories = await _categoriesRepository.GetAllCategories();

			return categories
				.Select(temp => temp.ToCategoryResponse()).ToList();
		}

		public async Task<CategoryResponse> GetCategoryByCategoryId(Guid id)
		{
			if (id == null)
			{
				return null;
			}

			Category? category = await _categoriesRepository.GetCategoryByCategoryId(id);

			if (category == null)
			{
				return null;
			}

			return category.ToCategoryResponse();
		}
	}
}
