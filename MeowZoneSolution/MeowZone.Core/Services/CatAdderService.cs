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
	public class CatAdderService : ICatAdderService
	{
		private readonly ICatsRepository _catsRepository;

		public CatAdderService(ICatsRepository catRepository)
		{
			_catsRepository = catRepository;
		}

		public async Task<CatResponse> AddCat(CatAddRequest? catAddRequest)
		{
			if (catAddRequest == null)
			{
				throw new ArgumentNullException(nameof(catAddRequest));
			}

			Cat cat = catAddRequest.ToCat();

			cat.Id = Guid.NewGuid();

			await _catsRepository.AddCat(cat);

			return cat.ToCatResponse();
		}
	}
}
