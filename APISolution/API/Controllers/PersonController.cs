using API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonContext _personContext;

        public PersonController(PersonContext context)
        {
            _personContext = context;
        }

        [HttpPost]
        public JsonResult CreatePerson(Person person)
        {
            if(person.ID == 0)
            {
                _personContext.People.Add(person);  
            }
            else
            {
                var PersonInDb = _personContext.People.Find(person.ID);

                if (PersonInDb == null)
                {
                    return new JsonResult(NotFound());
                }
                else
                {
                    PersonInDb = person;
                }
            }

            _personContext.SaveChanges();
            return new JsonResult(Ok(person));
        }
    }
}
