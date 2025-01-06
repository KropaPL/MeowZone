using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Models;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICatGetterService
	{
		Task<List<CatResponse>> getAllCats();
		Task<CatResponse> GetCatByCatId(Guid? guid);
	}
}
