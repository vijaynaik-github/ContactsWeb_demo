using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contact_API.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                ContactsDBEntities entities = new ContactsDBEntities();
                return View(entities.Contacts);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
