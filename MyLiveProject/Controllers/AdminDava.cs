using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminDava : Controller
    {
        DavaManager dm = new DavaManager(new EfDavaRepository());   
        EfDavaRepository efDavaRepository = new EfDavaRepository(); 
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var values = dm.GetList().OrderByDescending(x=>x.DavaID).ToPagedList(page,5);
            return View(values);
        }
        [HttpGet]
        public IActionResult AddDava()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDava(Dava p)
        {
            dm.TAdd(p);
            return RedirectToAction("Index", "AdminDava");
        }

        public IActionResult davaDelete(int ID)
        {
            var values = dm.GetByID(ID);
            dm.TDelete(values);
            return RedirectToAction("Index", "AdminDava");
        }

        [HttpGet]
        public IActionResult davaUpdate(int ID)
        {
            var values = dm.GetByID(ID);
            return View(values);
        }

        [HttpPost]
        public IActionResult davaUpdate(Dava p)
        {
            var x = efDavaRepository.GetById((int)p.DavaID);
            x.DavaName = p.DavaName;
            x.DavaDescription = p.DavaDescription;
            x.DavaDate = p.DavaDate;
            x.DavaIcon = p.DavaIcon;
            x.DavaStatus = p.DavaStatus;
            dm.TUpdate(x);
            return RedirectToAction("Index", "AdminDava");
        }
    }
}
