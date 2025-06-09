using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    public class AboutController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminRepository());
        [AllowAnonymous]
        public IActionResult Index()
        {
            ModelViewControl modelView = new ModelViewControl();
            modelView.Adminmodel = am.GetList();

            return View(modelView);
        }
    }
}
