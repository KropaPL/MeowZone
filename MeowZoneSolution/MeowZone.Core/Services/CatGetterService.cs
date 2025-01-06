using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Core.DTO;
using MeowZone.Core.ServiceContracts;
using MeowZone.Models;

namespace MeowZone.Core.Services
{
	public class CatGetterService : ICatGetterService
	{
		private readonly ICatsRepository _catsRepository;

		public CatGetterService(ICatsRepository catsRepository)
		{
			_catsRepository = catsRepository;
		}

		public async Task<List<CatResponse>> getAllUserCats(Guid guid)
		{
			var cats = await _catsRepository.GetCatsByUserId(guid);
			return cats
				.Select(temp => temp.ToCatResponse()).ToList();
		}

		public async Task<CatResponse> GetCatByCatId(Guid? guid)
		{
			if (guid == null)
			{
				return null;
			}

			Cat? cat = await _catsRepository.GetCatByCatId(guid.Value);

			if (cat == null)
			{
				return null;
			}

			return cat.ToCatResponse();
		}
	}
}
