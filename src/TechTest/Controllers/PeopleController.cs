using System;
using Microsoft.AspNetCore.Mvc;
using TechTest.Repositories;
using TechTest.Repositories.Models;

namespace TechTest.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        public PeopleController(IPersonRepository personRepository)
        {
            this.PersonRepository = personRepository;
        }

        private IPersonRepository PersonRepository { get; }

        [HttpGet]
        public IActionResult GetAll()
        {

            var people = this.PersonRepository.GetAll();

            return this.Ok(people);

            throw new NotImplementedException();
        }

        [HttpGet("GetAllPeoples")]
        public JsonResult GetAllPeoples()
        {
            return Json(PersonRepository.getInstance().GetAll());
        }

           
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            if (!PersonRepository.Get(id, out var people))
            {
                return NotFound();
            }

            return people;

            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Update(int id, PersonUpdate personUpdate)
        {

            if (!PersonRepository.Update(id, out var personUpdate))
            {
                return NotFound();
            }


        throw new NotImplementedException();
        }
    }
}