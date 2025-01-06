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
	public class CatsAdderService : ICatsAdderService
	{
		private readonly ICatsRepository _catsRepository;

		public CatsAdderService(ICatsRepository catRepository)
		{
			_catsRepository = catRepository;
		}

		public async Task<CatResponse> AddCat(CatAddRequest? catAddRequest, Guid OwnerId)
		{
			if (catAddRequest == null)
			{
				throw new ArgumentNullException(nameof(catAddRequest));
			}

			Cat cat = catAddRequest.ToCat();

			cat.Id = Guid.NewGuid();
			cat.OwnerId = OwnerId;

			await _catsRepository.AddCat(cat);

			return cat.ToCatResponse();
		}
	}
}
