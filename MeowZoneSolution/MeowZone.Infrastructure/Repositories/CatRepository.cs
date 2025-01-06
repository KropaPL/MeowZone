using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeowZone.Core.Domain.RepositoryContracts;
using MeowZone.Infrastructure.DbContext;
using MeowZone.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace MeowZone.Infrastructure.Repositories
{
	public class CatsRepository : ICatsRepository
	{
		private readonly ApplicationDbContext _db;

		public CatsRepository(ApplicationDbContext db)
		{
			_db = db;
		}
		public async Task<Cat> AddCat(Cat cat)
		{
			_db.Cats.Add(cat);
			await _db.SaveChangesAsync();

			return cat;
		}

		public async Task<Cat> UpdateCat(Cat cat)
		{
			Cat? matchingCat = await _db.Cats.FirstOrDefaultAsync(temp => temp.Id == cat.Id);

			if (matchingCat == null)
				return cat;

			matchingCat.Name = cat.Name;
			matchingCat.Age = cat.Age;
			matchingCat.Breed = cat.Breed;
			matchingCat.Color = cat.Color;
			matchingCat.Gender = cat.Gender;
			matchingCat.Weight = cat.Weight;

			int countUpdated = await _db.SaveChangesAsync();

			return matchingCat;
		}

		public async Task<bool> DeleteCat(Guid catId)
		{
			_db.Cats.RemoveRange(_db.Cats.Where(temp => temp.Id == catId));
			int rowsDeleted = await _db.SaveChangesAsync();

			return rowsDeleted > 0;
		}

		public async Task<Cat> GetCatByCatId(Guid catId)
		{
			return await _db.Cats.FirstOrDefaultAsync(temp => temp.Id == catId);
		}

		public async Task<List<Cat>> GetCatsByUserId(Guid userId)
		{
			return await _db.Cats.Where(temp => temp.OwnerId == userId).ToListAsync();
		}
	}
}
