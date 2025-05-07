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

        [HttpGet("lastid")]
        public ActionResult<int> GetLastId()
        {
            int lastId = _packagedUnitRepo.GetLastId();
            return Ok(lastId);
        }

        [HttpPost]
        public ActionResult Post([FromBody] PackagedUnit item)
        {
            if (item == null) {
                return BadRequest("invalid data.");
            }

            int newId = _packagedUnitRepo.SaveNew(item);
            return Ok(newId);
            //return CreatedAtAction(nameof(GetById), new {id = item.Id},item);

        }

        [HttpPost("update")]
        public ActionResult Update([FromBody] PackagedUnit item)
        {
            if (item == null || item.Id <= 0)
            {
                return BadRequest("invalid data.");
            }

            bool result = _packagedUnitRepo.Update(item);
            if (result)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }




    }
}
