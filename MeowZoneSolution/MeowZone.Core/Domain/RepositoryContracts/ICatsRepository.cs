using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Models;

namespace MeowZone.Core.Domain.RepositoryContracts
{
    public interface ICatsRepository
    {
        /// <summary>
        /// Adds a cat object to the database
        /// </summary>
        /// <param name="cat">Cat object to add</param>
        /// <returns>Returns the cat object after adding it to the database</returns>
        Task<Cat> AddCat(Cat cat);

        /// <summary>
        /// Updates a cat object in the database
        /// </summary>
        /// <param name="cat">Cat object to update</param>
        /// <returns>Returns the updated cat object</returns>
        Task<Cat> UpdateCat(Cat cat);

		/// <summary>
		/// Deletes a cat based on the cat id 
		/// </summary>
		/// <param name="catId">CatID (guid) to delete</param>
		/// <returns>Return true if the deletion is successful; otherwise, return false.</returns>
		Task<bool> DeleteCat(Guid catId);

        /// <summary>
        /// Returns a cat object based on the given cat id 
        /// </summary>
        /// <param name="catId">CatID (guid) to search</param>
        /// <returns>A cat object or null</returns>
        Task<Cat> GetCatByCatId(Guid catId);

		/// <summary>
		/// Returns a list of cats based on the given user ID
		/// </summary>
		/// <param name="userId">UserID to search by</param>
		/// <returns>A cat object or null</returns>
		Task<List<Cat>> GetCatsByUserId(Guid userId);
    }
}
