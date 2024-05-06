using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.DataAccess.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
	{
		private CafeBookDbContext _dbContext;
		public CompanyRepository(CafeBookDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(Company obj)
		{
			_dbContext.Companies.Update(obj);
		}
	}
}
