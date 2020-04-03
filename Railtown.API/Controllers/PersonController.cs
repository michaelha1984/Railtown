using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Railtown.Data.Services;

namespace Railtown.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService)
        {
            this.personService = personService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var result = await personService.GetPersonsFurthestApartAsync();

            return Ok(result);
        }
    }
}