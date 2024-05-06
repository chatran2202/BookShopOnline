using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Entities.Models;
using CafeBook.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CafeBook.Web.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.productRepo.GetAll(includeProperties:"Category");
            return View(productList);
		}

		public IActionResult Details(int productId)
		{
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.productRepo.Get(p => p.Id == productId, includeProperties: "Category"),
                Count = 1,
                ProductId = productId
            };
			return View(cart);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.CafeBookUserId = userId;
            ShoppingCart cartFromDB = _unitOfWork.shoppingCartRepo.Get(u => u.CafeBookUserId == userId && u.ProductId == shoppingCart.ProductId);

            if (cartFromDB !=null)
            {
                //shopping cart exist
                cartFromDB.Count += shoppingCart.Count;
                _unitOfWork.shoppingCartRepo.Update(shoppingCart);
            }
            else
            {
                //add cart to record
                _unitOfWork.shoppingCartRepo.Add(shoppingCart);
            }
            TempData["success"] = "Cart update successfully!";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
