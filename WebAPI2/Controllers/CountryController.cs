using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountryController : ControllerBase
    {
        private static readonly List<Country> Countries = new List<Country> {
            new Country(){CountryId=1,CountryCode="JOD",CountryName="Jordan" },
            new Country(){CountryId=2,CountryCode="KSA",CountryName="Saudi Arabia" },
            new Country(){CountryId=3,CountryCode="UAE",CountryName="United Arab Emirates" },
            new Country(){CountryId=4,CountryCode="USA",CountryName="United States" },
        };

        [HttpGet("Get.{format}"), FormatFilter]
        public List<Country> Get()
        {
            try
            {
                return Countries;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
