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
	public class CatsUpdaterService : ICatsUpdaterService
	{
		private readonly ICatsRepository _catsRepository;

		public CatsUpdaterService(ICatsRepository catsRepository)
		{
			_catsRepository = catsRepository;
		}

		public async Task<CatResponse> UpdateCat(CatUpdateRequest? catUpdateRequest)
		{
			if (catUpdateRequest == null)
			{
				throw new ArgumentNullException(nameof(catUpdateRequest));
			}

			Cat? matchingCat = await _catsRepository.GetCatByCatId(catUpdateRequest.Id);

			if (matchingCat == null)
			{
				throw new ArgumentNullException(nameof(catUpdateRequest));
			}

			matchingCat.Name = catUpdateRequest.Name;
			matchingCat.Gender = catUpdateRequest.Gender;
			matchingCat.Age = catUpdateRequest.Age;
			matchingCat.Breed = catUpdateRequest.Breed;
			matchingCat.Color = catUpdateRequest.Color;
			matchingCat.Weight = catUpdateRequest.Weight;

			await _catsRepository.UpdateCat(matchingCat);

			return matchingCat.ToCatResponse();

		}
	}
}
