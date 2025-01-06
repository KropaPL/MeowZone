using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;

namespace MeowZone.Core.Services
{
	public class CategoriesUpdaterService : ICategoryUpdaterService
	{
		public Task<CategoryResponse> UpdateCategory(CategoryUpdateRequest? categoryUpdateRequest)
		{
			throw new NotImplementedException();
		}
	}
}
