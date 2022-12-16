using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AspnetFramework.Controllers
{
    public class PersonneController : Controller
    {
        // GET: Personne
        public ActionResult Index()
        {
            return View();
        }
        public string Test1()
        {
            return "Page result1";
        }
        public ActionResult Test3()
        {
            return RedirectToAction("Test1");
        }
        public ActionResult Test2()
        {
            var c = new ContentResult();
            c.ContentType = "application/text";
            c.ContentEncoding = Encoding.ASCII;
            c.Content = "Page result 2 ça coûte 20€";
            return c;
        }
    }
}