﻿using MeowZone.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeowZone.Core.ServiceContracts
{
	public interface ICategoryAdderService
	{
		public Task<CategoryResponse> AddCategory(CategoryAddRequest? categoryAddRequest);
	}
}
