using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        AdminManager am = new AdminManager(new EfAdminRepository());
        ModelViewControl modelView = new ModelViewControl();
        [AllowAnonymous]
        [HttpGet]
       
        public IActionResult Index()
        {
            modelView.Adminmodel = am.GetList();
            return View(modelView);
        }
        [AllowAnonymous]
        [HttpPost]
       
        public IActionResult Index(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = false;
            try
            {
                cm.TAdd(p);
                TempData["Message"] = "Mesajınız başarılı bir şekilde iletilmiştir. Teşekkürler";
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Mesajınız iletilemedi." + ex.Message;
            }

            return RedirectToAction("Index", "Contact");
        }
    }
}
