using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;

namespace MeowZone.Core.Services
{
	public class CategoriesUpdaterService : ICategoryUpdaterService
	{
		private readonly ICategoriesRepository _categoriesRepository;

		public CategoriesUpdaterService(ICategoriesRepository categoriesRepository)
		{
			_categoriesRepository = categoriesRepository;
		}
		public async Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? categoryUpdateRequest)
		{
			if (categoryUpdateRequest == null)
			{
				throw new ArgumentNullException(nameof(categoryUpdateRequest));
			}

			Category? matchingCategory = await _categoriesRepository.GetCategoryByCategoryId(categoryUpdateRequest.Id);

			if (matchingCategory == null)
			{
				throw new ArgumentNullException(nameof(categoryUpdateRequest));
			}

			matchingCategory.Name = categoryUpdateRequest.Name;
			matchingCategory.Description = categoryUpdateRequest.Description;

			await _categoriesRepository.UpdateCategory(matchingCategory);

			return matchingCategory.ToCategoryResponse();
		}

	}
}
