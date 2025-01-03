using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Models;

namespace MeowZone.Core.Domain.RepositoryContracts
{
    public interface ICatRepository
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
        /// <param name="cat">CatID (guid) to delete</param>
        /// <returns></returns>
        Task<Cat> DeleteCat(Guid catID);

        /// <summary>
        /// Returns a cat object based on the given cat id 
        /// </summary>
        /// <param name="catID">CatID (guid) to search</param>
        /// <returns></returns>
        Task<Cat> GetCatByCatID(Guid catID);
    }
}
