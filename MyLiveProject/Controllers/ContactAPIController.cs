using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyLiveProject.Controllers
{  
    [ApiController]
    [Route("api/[controller]")]

    public class ContactAPIController : ControllerBase
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        EfContactRepository efContact = new EfContactRepository();
        [AllowAnonymous]
        [HttpGet]   
        public IActionResult ContactAPI()
        {
            var values = cm.GetList();
            return Ok(values);
        }
        [AllowAnonymous]
        [HttpGet("{id}")]
        public ActionResult ContactAPI(int id)
        {
            var values = cm.GetByID(id);
            return Ok(values);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult ContactAPI(Contact p)
        {
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.ContactStatus = false;
            cm.TAdd(p);
            return Ok(p);
        }

        [AllowAnonymous]
        [HttpDelete("{id}")]
        public ActionResult ContactAPIDELETE(int id)
        {
            var values = cm.GetByID(id);
            cm.TDelete(values);
            return Ok(values);
        }
    }
}
