using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public string GetData() { return "Hello en Get"; }
        [Route("{id}")]
        public string GetData2(int id) { return $"Hello en Get: {id}"; }
        [Route("/version/{id}")]
        public string GetData4(int id) { return $"Hello en Get: {id} "; }
        [Route("{department}/{service}")]
        public string GetData3(string department, string service) { return $"Hello en Get: {department}.{service} "; }
        [HttpPost]
        public string PostData() { return "Hello en Post"; }
    }
}
