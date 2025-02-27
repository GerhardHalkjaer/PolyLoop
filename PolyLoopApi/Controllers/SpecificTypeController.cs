using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolyLoopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificTypeController : ControllerBase
    {
        private readonly SpecificTypeRepo _specificTypeRepo;

        public SpecificTypeController(SpecificTypeRepo InSpecificTypeRepo)
        {
            _specificTypeRepo = InSpecificTypeRepo;
        }

        [HttpGet]
        public ActionResult<List<SpecificType>> GetAll()
        {
            List<SpecificType> result = _specificTypeRepo.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<List<SpecificType>> GetById(int id)
        {
            List<SpecificType> result = _specificTypeRepo.GetById(id);//change
            return result;
        }

    }
}
