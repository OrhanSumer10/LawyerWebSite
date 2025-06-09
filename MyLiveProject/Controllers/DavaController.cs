using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    public class DavaController : Controller
    {
        DavaManager dm = new(new EfDavaRepository());
        AdminManager am = new(new EfAdminRepository());
        Context c = new();
        ModelViewControl modelView = new();
        [AllowAnonymous]
        public IActionResult Index()
        {
            modelView.Davamodel = dm.GetDavaListStatus();
            return View(modelView);
        }
        [AllowAnonymous]
        public IActionResult MoreDava(int ID)
        {
            modelView.Davamodel = dm.GetDava(ID);
            modelView.Adminmodel = am.GetList();
            return View(modelView);
        }

    }
}
