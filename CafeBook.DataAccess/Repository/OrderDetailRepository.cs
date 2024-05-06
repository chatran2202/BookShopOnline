using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CafeBook.DataAccess.Repository
{
	public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
		private CafeBookDbContext _dbContext;
		public OrderDetailRepository(CafeBookDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(OrderDetail obj)
		{
			_dbContext.OrderDetails.Update(obj);
		}
	}
}
