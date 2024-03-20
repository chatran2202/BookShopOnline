using CafeBook.Web.Data;
using CafeBook.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeBook.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CafeBookDbContext _dbContext;
        public CategoryController(CafeBookDbContext db)
        {
            _dbContext = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryLst = _dbContext.Categories.ToList();
            return View(objCategoryLst);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The Name must be difference from DisplayOrder");
            }

            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(obj);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
            {
				return NotFound();
			}
			Category categoryFromDb = _dbContext.Categories.Find(id);
			Category categoryFromDb1 = _dbContext.Categories.FirstOrDefault(o => o.Id == id);
			Category categoryFromDb2 = _dbContext.Categories.Where(o => o.Id == id).FirstOrDefault();
			if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The Name must be difference from DisplayOrder");
			}

			if (ModelState.IsValid)
			{
				_dbContext.Categories.Add(obj);
				_dbContext.SaveChanges();
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
