using MeowZone.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.DTO;
using MeowZone.Core.Domain.RepositoryContracts;

namespace MeowZone.Core.Services
{
	public class CategoriesAdderService : ICategoryAdderService
	{
		private readonly ICategoriesRepository _categoriesRepository;

		public CategoriesAdderService(ICategoriesRepository categoriesRepository)
		{
			_categoriesRepository = categoriesRepository;
		}
		public async Task<CategoryResponse> AddCategory(CategoryAddRequest? categoryAddRequest)
		{
			if (categoryAddRequest == null)
			{
				throw new ArgumentNullException(nameof(categoryAddRequest));
			}

			Category category = categoryAddRequest.ToCategory();

			category.Id = Guid.NewGuid();

			await _categoriesRepository.AddCategory(category);

			return category.ToCategoryResponse();
		}
	}
}
