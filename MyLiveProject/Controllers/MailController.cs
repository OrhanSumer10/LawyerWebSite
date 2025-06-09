using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using MyLiveProject.Models;

namespace MyLiveProject.Controllers
{
    public class MailController : Controller
    {
        SubManager sm = new SubManager(new EfSubRepoditory());

        [HttpGet]
        public IActionResult Index()
        {
            List<SelectListItem> value = (from x in sm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.SubEmail
                                          }).ToList();
            ViewBag.cvalue = value;
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailRequest mail)
        {
           
            return View();
        }
    }
}
