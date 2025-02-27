using Entities;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace PolyLoopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialTypeController : ControllerBase
    {
        private readonly MaterialTypeRepo _materialTypeRepo;

        public MaterialTypeController(MaterialTypeRepo matTypeRepo)
        {
            _materialTypeRepo = matTypeRepo;
        }


        [HttpGet]
        public ActionResult<List<MaterialType>> GetAll()
        {
            List<MaterialType> result = _materialTypeRepo.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<List<MaterialType>> GetById(int id)
        {
            List<MaterialType> result = _materialTypeRepo.GetById(id);//change
            return result;
        }


    }
}
