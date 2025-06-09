using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using X.PagedList;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminCategory : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        EfCategoryRepository efCategory = new EfCategoryRepository();
        Context c = new Context();

        public IActionResult Index(int page =1)
        {
            var values = cm.GetList().OrderByDescending(x=>x.CategoryID).ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public IActionResult addCategory()
        {
            return View();  
        }

        [HttpPost]
        public IActionResult addCategory(Category p)
        {
            cm.TAdd(p);  
            return RedirectToAction("Index", "AdminCategory");  
        }

        public IActionResult DeleteCategory(int ID)
        {
            var values = cm.GetByID(ID);
            cm.TDelete(values);
            return RedirectToAction("Index", "AdminCategory");
        }

        [HttpGet]
        public IActionResult updateCategory(int ID)
        {
            var values = cm.GetByID(ID);
            return View(values);    
        }
        [HttpPost]
        public IActionResult updateCategory(Category p)
        {
            var x = efCategory.GetById((int)p.CategoryID);
            x.CategoryName = p.CategoryName;
            x.CategoryDate = p.CategoryDate;
            x.CategoryIcon = p.CategoryIcon;
            x.CategoryStatus = p.CategoryStatus;
            cm.TUpdate(x);
            return RedirectToAction("Index", "AdminCategory");
        }
    }
}
