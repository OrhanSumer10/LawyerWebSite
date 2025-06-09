using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Permissions;
using X.PagedList;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        EfContactRepository efContact = new EfContactRepository();
        public IActionResult Index(int page = 1)
        {
            var values = cm.GetList().OrderByDescending(x=>x.ContactID).ToPagedList(page, 5) ;
            return View(values);
        }
        public  IActionResult DeleteMessage(int ID)
        {
            var values = cm.GetByID(ID);
            cm.TDelete(values);
            return RedirectToAction("Index","AdminContact");
        }
        [HttpGet]
        public IActionResult UpdateMessage(int ID)
        {
            var x = cm.GetByID(ID);
            return View(x);
        }

        [HttpPost]
        public IActionResult UpdateMessage(Contact p)
        {
            var x = efContact.GetById((int)p.ContactID);
            x.ContactStatus = true;
            cm.TUpdate(x);
            return RedirectToAction("Index", "AdminContact");

        }
    }
}
