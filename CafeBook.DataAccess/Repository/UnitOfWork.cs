using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBook.DataAccess.Repository
{
	public class UnitOfWork : IUnitOfWork
	{
		private CafeBookDbContext _dbContext;
		public ICategoryRepository categoryRepo { get; private set; }
        public IProductRepository productRepo { get; private set; }
		public ICompanyRepository companyRepo { get; private set; }
		public IShoppingCartRepository shoppingCartRepo { get; private set; }
		public IOrderHeaderRepository orderHeaderRepo { get; private set; }
		public IOrderDetailRepository orderDetailRepo { get; private set; }
		public ICafeBookUserRepository cafeBookUserRepo { get; private set; }

        public UnitOfWork(CafeBookDbContext dbContext)
		{
			_dbContext = dbContext;
			categoryRepo = new CategoryRepository(_dbContext);
            productRepo = new ProductRepository(_dbContext);
			companyRepo = new CompanyRepository(_dbContext);
			shoppingCartRepo = new ShoppingCartRepository(_dbContext);
			orderHeaderRepo = new OrderHeaderRepository(_dbContext);
			orderDetailRepo = new OrderDetailRepository(_dbContext);
			cafeBookUserRepo = new CafeBookUserRepository(_dbContext);
		}

		public void Save()
		{
			_dbContext.SaveChanges();
		}
	}
}
