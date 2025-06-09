using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        MakaleManager mm = new MakaleManager(new EfMakaleRepository());
        DavaManager dm = new DavaManager(new EfDavaRepository());
        ContactManager cm = new ContactManager(new EfContactRepository());
        SubManager sm = new SubManager(new EfSubRepoditory());
        Context c = new Context();
        public IActionResult Index()
        {
            var makalesayisi = mm.GetList().Count;
            ViewBag.ms = makalesayisi;
            var davasayisi = dm.GetList().Count;
            ViewBag.ds = davasayisi;
            var aktifmsayisi = (from x in c.makales
                                where x.MakaleStatus == true
                                select x).Count();
            ViewBag.ams = aktifmsayisi;
            var pasifmsayisi = (from x in c.makales
                                where x.MakaleStatus == false
                                select x).Count();
            ViewBag.pms = pasifmsayisi;
            var toplammesaj = cm.GetList().Count;
            ViewBag.toplamM = toplammesaj;
            var toplamsub = sm.GetList().Count;
            ViewBag.toplamSub = toplamsub;
            var Okunmayanmesaj = (from x in c.contacts
                               where x.ContactStatus == false
                               select x).Count();
            ViewBag.om = Okunmayanmesaj;
            var values = mm.GetList().OrderByDescending(x => x.MakaleID).Take(3).ToList();
            return View(values);
        }
    }
}
