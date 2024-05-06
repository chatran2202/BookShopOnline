using CafeBook.DataAccess.Data;
using CafeBook.DataAccess.Repository.IRepository;
using CafeBook.Models.Entities;
using CafeBook.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CafeBook.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> objCompanyList = _unitOfWork.companyRepo.GetAll().ToList();
            
            return View(objCompanyList);
        }

        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                //create
                return View(new Company());
            }
            else
            {
                //update
                Company companyObj = _unitOfWork.companyRepo.Get(p => p.Id == id, includeProperties:"");
                return View(companyObj);
            }

        }
        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
                if(CompanyObj.Id == 0)
				{
					_unitOfWork.companyRepo.Add(CompanyObj);
				}
                else
                {
                    _unitOfWork.companyRepo.Update(CompanyObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Successful!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> objCompanyList = _unitOfWork.companyRepo.GetAll().ToList();
            return Json(new {data=objCompanyList});
        }
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var CompanyToBeDel = _unitOfWork.companyRepo.Get(p=>p.Id == id);
            if (CompanyToBeDel == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.companyRepo.Remove(CompanyToBeDel);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful!" });
        }
        #endregion
    }
}
