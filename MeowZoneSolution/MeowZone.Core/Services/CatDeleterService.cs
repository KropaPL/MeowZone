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
		private readonly ICatsRepository _catsRepository;

		public CatDeleterService(ICatsRepository catRepository)
		{
			_catsRepository = catRepository;
		}
		public async Task<bool> DeleteCat(Guid id)
		{
			if (id == null)
			{
				throw new ArgumentNullException(nameof(id));
			}

			Cat? cat = await _catsRepository.GetCatByCatId(id);
			if (cat == null)
			{
				return false;
			}

			await _catsRepository.DeleteCat(id);

			return true;
		}
	}
}
