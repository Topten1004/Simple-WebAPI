using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using WebAPIWithDapperandSwagger.Models;
using WebAPIWithDapperandSwagger.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPIWithDapperandSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactMasterController : Controller
    {
        private readonly IContactMasterRepository _contactMasterRepo;

        public ContactMasterController(IContactMasterRepository contactMasterRepo)
        {
            _contactMasterRepo = contactMasterRepo;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ContactMaster>> GetByID(int id)
        {
            return await _contactMasterRepo.GetByID(id);
        }

        [HttpGet]
        public async Task<ActionResult<List<ContactMaster>>> GetAll()
        {
            return await _contactMasterRepo.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<ContactMaster>> Edit([FromBody]ContactMaster contactMaster)
        {
            if (contactMaster == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid State");
            }

            return await _contactMasterRepo.Edit(contactMaster);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ContactMaster>> DeleteById(int id)
        {
            return await _contactMasterRepo.Delete(id);
        }

    }
}
