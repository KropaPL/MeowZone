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
		private readonly ICatRepository _catRepository;

		public CatAdderService(ICatRepository catRepository)
		{
			_catRepository = catRepository;
		}

		public async Task<CatResponse> AddCat(CatAddRequest? catAddRequest)
		{
			if (catAddRequest == null)
			{
				throw new ArgumentNullException(nameof(catAddRequest));
			}

			Cat cat = catAddRequest.ToCat();

			cat.Id = Guid.NewGuid();

			await _catRepository.AddCat(cat);

			return cat.ToCatResponse();
		}
	}
}
