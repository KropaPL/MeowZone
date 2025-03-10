﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;
using MeowZone.Models;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICatsGetterService
	{
		Task<List<CatResponse>> getAllUserCats(Guid guid);
		Task<CatResponse> GetCatByCatId(Guid? guid);
	}
}
