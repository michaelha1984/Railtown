using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Railtown.API.Models;
using Railtown.Data.Services;

namespace Railtown.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService personService;
        private readonly IMapper mapper;

        public PersonController(IPersonService personService,
            IMapper mapper)
        {
            this.personService = personService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var persons = await personService.GetPersonsFurthestApartAsync();
            var result = mapper.Map<PersonsFurthestApart>(persons);
            return Ok(result);
        }
    }
}