using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;

namespace CafeBook.DataAccess.Repository
{
	public class ProductRepository : Repository<Product>, IProductRepository
	{
		private CafeBookDbContext _dbContext;
		public ProductRepository(CafeBookDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}

		public void Update(Product obj)
		{
			var objFromDb = _dbContext.Products.FirstOrDefault(p => p.Id == obj.Id);
			if (objFromDb != null)
			{
				objFromDb.Title = obj.Title;
				objFromDb.Description = obj.Description;
				objFromDb.ISBN = obj.ISBN;
				objFromDb.Author = obj.Author;
				objFromDb.ListPrice = obj.ListPrice;
				objFromDb.Price1 = obj.Price1;
				objFromDb.Price50 = obj.Price50;
				objFromDb.Price100 = obj.Price100;
				objFromDb.CategoryId = obj.CategoryId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
		}
	}
}
