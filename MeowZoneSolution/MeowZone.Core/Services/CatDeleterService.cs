using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.ServiceContracts;
using MeowZone.Models;

namespace MeowZone.Core.Services
{
	public class CatDeleterService : ICatDeleterService
	{
		private readonly ICatRepository _catRepository;

		public CatDeleterService(ICatRepository catRepository)
		{
			_catRepository = catRepository;
		}
		public async Task<bool> DeleteCat(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			Cat? cat = await _catRepository.GetCatByCatId(id);
			if (cat == null)
			{
				return false;
			}

			await _catRepository.DeleteCat(id);

			return true;
		}
	}
}
