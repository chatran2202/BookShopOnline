using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.DataAccess.Repository
{
	public class CafeBookUserRepository : Repository<CafeBookUser>, ICafeBookUserRepository
    {
		private CafeBookDbContext _dbContext;
		public CafeBookUserRepository(CafeBookDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

	}
}
