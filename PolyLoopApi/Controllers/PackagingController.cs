using DataAccess;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PolyLoopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagingController : ControllerBase
    {
        private readonly PackagingRepo _packagingRepo;

        public PackagingController(PackagingRepo InPackagingRepo)
        {
            _packagingRepo = InPackagingRepo;
        }

        [HttpGet]
        public ActionResult<List<Packaging>> GetAll()
        {
            List<Packaging> result = _packagingRepo.GetAll();
            return result;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Packaging>> GetById(int id)
        {
            List<Packaging> result = _packagingRepo.GetById(id);//change
            return result;
        }


    }
}
