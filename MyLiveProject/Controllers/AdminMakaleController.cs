using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
using MyLiveProject.Models;
using MailKit.Net.Smtp;
using X.PagedList;
using MimeKit.Encodings;
using System.Collections.Generic;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminMakaleController : Controller
    {
        MakaleManager mm = new MakaleManager(new EfMakaleRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        EfMakaleRepository efMakaleRepository = new EfMakaleRepository();
        SubManager sm = new SubManager(new EfSubRepoditory());
        Context c = new Context();
        public IActionResult Index(int page = 1)
        {
            var values = mm.GetCategoryList().OrderByDescending(x => x.MakaleID).ToPagedList(page, 5);            
            return View(values);
        }

        [HttpGet]
        public IActionResult addMakale()
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            return View();
        }

        [HttpPost]
        public IActionResult addMakale(Makale p, MailRequest mail)
        {
            List<SelectListItem> value = (from x in sm.GetList()
                                          select new SelectListItem
                                          {
                                              Text = x.SubEmail
                                          }).ToList();
            List<SelectListItem> idCount = (from x in mm.GetList()
                           select new SelectListItem
                           {
                               Text = x.MakaleID.ToString(),
                           }).ToList();
            if (value.Count == 0)
            {
                mm.TAdd(p);

            }
            else
            {
                MimeMessage mime = new MimeMessage();
                MailboxAddress mailboxfrom = new MailboxAddress("Av Bilge Güler", "avbilgeguler@gmail.com");
                mime.From.Add(mailboxfrom);
                foreach (var item in value)
                {
                    MailboxAddress mailboxTo = new MailboxAddress("User", item.Text);
                    mime.To.Add(mailboxTo);
                }
                var bodybuilder = new BodyBuilder();
                bodybuilder.TextBody = "Yeni Makale Yayında sizler için faydalı olabilecek bir makale olduğunu düşünüyorum.\n http://bilgeguler.av.tr/Makale/ReadMakale/" + idCount[0].Text + "";
                mime.Body = bodybuilder.ToMessageBody();

                mime.Subject = "Yeni Makale Yayında";

                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate("avbilgeguler@gmail.com", "loet nrgc fztz elpb");

                client.Send(mime);
                client.Disconnect(true);
                mm.TAdd(p);
            }

            return RedirectToAction("Index", "AdminMakale");
        }

        public IActionResult deleteMakale(int ID)
        {

            var values = mm.GetByID(ID);
            mm.TDelete(values);
            return RedirectToAction("Index", "AdminMakale");
        }

        [HttpGet]
        public IActionResult updateMakale(int ID)
        {
            List<SelectListItem> categoryValue = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.cv = categoryValue;
            var values = mm.GetByID(ID);
            return View(values);
        }
        [HttpPost]
        public IActionResult updateMakale(Makale p)
        {
            var x = efMakaleRepository.GetById((int)p.MakaleID);
            x.MakaleTitle = p.MakaleTitle;
            x.MakaleContent = p.MakaleContent;
            x.CategoryID = p.CategoryID;
            x.MakaleImage = p.MakaleImage;
            x.MakaleCreateDate = p.MakaleCreateDate;
            x.MakaleStatus = p.MakaleStatus;
            mm.TUpdate(x);
            return RedirectToAction("Index", "AdminMakale");
        }
    }
}
