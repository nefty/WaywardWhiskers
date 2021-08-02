using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
using Capstone.DAO;
using Capstone.DAO.Interfaces;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private IPetDAO petDAO;

        public PetsController(IPetDAO petDAO)
        {
            this.petDAO = petDAO;
        }
        [HttpGet]
        public ActionResult<List<Pet>> GetAllPets()
        {
            return Ok(petDAO.GetAllPets());
        }

        [HttpGet("{petId}")]
        public ActionResult<Pet> GetPet(int petId)
        {
            return Ok(petDAO.GetPet(petId));
        }

    }
}
