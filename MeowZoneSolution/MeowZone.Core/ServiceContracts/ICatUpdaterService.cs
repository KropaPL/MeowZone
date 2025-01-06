using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.DTO;

namespace MeowZone.Core.ServiceContracts
{
	/// <summary>
	/// Represents business logic (upload) for manipulating cat entity
	/// </summary>
	public interface ICatUpdaterService
	{
		/// <summary>
		/// Updates the specified cat details based on the given cat ID
		/// </summary>
		/// <param name="catUpdateRequest">Cat details to update, including Cat id</param>
		/// <returns>Returns the cat response object after update</returns>
		Task<CatResponse> UpdateCat(CatUpdateRequest? catUpdateRequest);
	}
}
