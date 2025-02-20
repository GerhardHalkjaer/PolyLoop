using Entities;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolyLoopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<MaterialType>> GetAll()
        {
            MaterialTypeRepo materialType = new MaterialTypeRepo();
            List<MaterialType> result = materialType.GetAll();
            return result;
        }
    }
}
