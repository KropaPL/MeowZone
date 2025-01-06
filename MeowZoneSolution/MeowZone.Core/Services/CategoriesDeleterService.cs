using MeowZone.Core.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.Entities;
using MeowZone.Core.Domain.RepositoryContracts;

namespace MeowZone.Core.Services
{
	public class CategoriesDeleterService : ICategoryDeleterService
	{
		private readonly ICategoriesRepository _categoriesRepository;

		public CategoriesDeleterService(ICategoriesRepository categoriesRepository)
		{
			_categoriesRepository = categoriesRepository;
		}

		public async Task<bool> DeleteCategory(Guid categoryId)
		{
			if (categoryId == null)
			{
				throw new ArgumentNullException(nameof(categoryId));
			}

			Category? category = await _categoriesRepository.GetCategoryByCategoryId(categoryId);
			if (category == null)
			{
				return false;
			}

			await _categoriesRepository.DeleteCategory(categoryId);

			return true;
		}
	}
}
