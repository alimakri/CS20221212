using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspnetFramework.Controllers
{
    public class FormulaireController : Controller
    {
        // GET: Formulaire
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Personne p)
        {
            ViewBag.Personne = p;
            return View();
        }
    }
    public class Personne
    {
        public string Nom { get; set; }
        public bool Invite { get; set; }
    }
}