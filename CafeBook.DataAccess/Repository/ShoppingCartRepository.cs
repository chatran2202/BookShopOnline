using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.DataAccess.Repository
{
	public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
		private CafeBookDbContext _dbContext;
		public ShoppingCartRepository(CafeBookDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(ShoppingCart obj)
		{
			_dbContext.ShoppingCarts.Update(obj);
		}
	}
}
