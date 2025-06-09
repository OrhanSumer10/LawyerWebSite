using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyLiveProject.Models;
using System.Diagnostics;

namespace MyLiveProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        MakaleManager mm = new (new EfMakaleRepository());
        DavaManager dm = new (new EfDavaRepository());
        AdminManager am = new (new EfAdminRepository());
        Context c = new();
       
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;           
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            ModelViewControl modelView = new();
            modelView.makalemodel = mm.GetCategoryListStatusLast3();
            modelView.Davamodel = dm.GetDavaListStatus();
            modelView.Adminmodel = am.GetList();
      

            return View(modelView);
        }



        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}