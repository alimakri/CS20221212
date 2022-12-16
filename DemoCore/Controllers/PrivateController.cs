using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoCore.Controllers
{
    [Authorize]
    public class PrivateController : Controller
    {
        ILogger<PrivateController> Logger;
        public string RootFolder = string.Empty;
        public string ConnectionString = string.Empty;
        public PrivateController(ILogger<PrivateController> log, IWebHostEnvironment env, IConfiguration conf)
        {
            Logger= log;
            RootFolder = env.WebRootPath;
            ConnectionString = conf.GetValue<string>("ConnectionStrings:DefaultConnection");
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            Logger.LogInformation("Trace dans PrivateController.Index");
            //Serilog.Log.Information();
            ViewBag.Cnx = ConnectionString;
            return View();
        }
        public IActionResult Index2()
        {
            return View();
        }
    }
}
