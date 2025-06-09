using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminRepository());
        EfAdminRepository efAdmin = new EfAdminRepository();
        public IActionResult Index()
        {;
            ModelViewControl modelView = new ModelViewControl();

            modelView.Adminmodel = am.GetList();
            return View(modelView);    
        }




        public IActionResult UpdateContent(int ID)
        {
            ID = 1;
            var x = am.GetByID(ID);
            return View(x);
        }

        [HttpPost]
        public IActionResult UpdateContent(Admin p)
        {
            var x = efAdmin.GetById((int)p.AdminID);
            x.ImageUrl = p.ImageUrl;
            x.ShortDescription = p.ShortDescription;
            x.Banner = p.Banner;
            x.Adress = p.Adress;    
            x.PhoneNumber = p.PhoneNumber;  
            x.InstagramAdress = p.InstagramAdress;  
            x.FacebookAdress = p.FacebookAdress; 
            x.UserName = p.UserName;    
            am.TUpdate(x);
            return RedirectToAction("Index", "Settings");
        }
    }
}
