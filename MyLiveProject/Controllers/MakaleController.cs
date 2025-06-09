using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    public class MakaleController : Controller
    {
        MakaleManager mm = new MakaleManager(new EfMakaleRepository());
        AdminManager am = new AdminManager(new EfAdminRepository());
        Context c = new Context();
        ModelViewControl modelView = new ModelViewControl();
        [AllowAnonymous]
        public IActionResult Index()
        {
            
            modelView.makalemodel = mm.GetCategoryListStatus();
            modelView.Adminmodel = am.GetList();
            return View(modelView);
        }

        [AllowAnonymous]
        public IActionResult ReadMakale(int ID)
        {
            modelView.makalemodel = mm.GetMakID(ID);
            modelView.Adminmodel = am.GetList();
            return View(modelView);
        }
    }
}
