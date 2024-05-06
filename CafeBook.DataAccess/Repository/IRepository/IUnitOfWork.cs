using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeBook.DataAccess.Repository.IRepository
{
	public interface IUnitOfWork
	{
		ICategoryRepository categoryRepo { get; }
        IProductRepository productRepo { get; }
		ICompanyRepository companyRepo { get; }
        IShoppingCartRepository shoppingCartRepo { get; }
		IOrderHeaderRepository orderHeaderRepo { get; }
		IOrderDetailRepository orderDetailRepo { get; }
        ICafeBookUserRepository cafeBookUserRepo { get; }
        void Save();
	}
}
