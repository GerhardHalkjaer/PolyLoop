using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolyLoopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagedUnitController : ControllerBase
    {
        private readonly PackagedUnitRepo _packagedUnitRepo;

        public PackagedUnitController(PackagedUnitRepo InPackagedUnitRepo)
        {
            _packagedUnitRepo = InPackagedUnitRepo;
        }

        [HttpGet]
        public ActionResult<List<PackagedUnit>> GetAll()
        {
            List<PackagedUnit> result = _packagedUnitRepo.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<List<PackagedUnit>> GetById(int id)
        {
            List<PackagedUnit> result = _packagedUnitRepo.GetById(id);//change
            return result;
        }


    }
}
