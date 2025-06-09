
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace MyLiveProject.Controllers
{
    [Authorize]
    public class AdminSubController : Controller
    {
        SubManager sm = new SubManager(new EfSubRepoditory());


        public IActionResult Index(int page = 1)
        {
            var values = sm.GetList().OrderByDescending(x => x.SubID).ToPagedList(page, 5);
            return View(values);
        }

      
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Subscribe(SubScribe p)
        {
            p.SubDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.SubStatus = true;

            try
            {
                sm.TAdd(p);

                TempData["Message"] = "Abone olduğunuz için teşekkürler.";
            }
            catch (Exception ex)
            {

                TempData["Message"] = "Abone olduğunuz için teşekkürler." + ex.Message;
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public PartialViewResult Subscribe()
        {
            return PartialView();
        }


        public IActionResult DeleteSub(int ID)
        {
            var values = sm.GetByID(ID);
            sm.TDelete(values);
            return RedirectToAction("Index", "AdminSub");
        }
    }
}
