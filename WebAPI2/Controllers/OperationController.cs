using BasicAuthentication;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI2.Models;

namespace WebAPI2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : ControllerBase
    {
        [HttpPost("Calcolate.{format}"), FormatFilter]
        public int Calcolate(int fNumber, int sNumber)
        {
            try
            {
                return fNumber + sNumber;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("CalcolateObject.{format}"), FormatFilter]
        public NumbersResponse CalcolateObject([FromBody] NumbersRequest obj)
        {
            try
            {
                return new NumbersResponse()
                {
                    Result = obj.FNumber + obj.SNumber
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("GetDefaultNumbersObj.{format}"), FormatFilter]
        public NumbersRequest GetDefaultNumbersObj()
        {
            try
            {
                return new NumbersRequest()
                {
                    FNumber = 1,
                    SNumber = 3,
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }


        [BasicAuthentication]
        [HttpPost("Calcolate.{format}"), FormatFilter]
        public int AuthenticationCalcolate(int fNumber, int sNumber)
        {
            try
            {
                return fNumber + sNumber;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
