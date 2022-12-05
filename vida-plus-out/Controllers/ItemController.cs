﻿using vida_plus_out.Item;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using vida_plus_out.Mapper;

namespace vida_plus_out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class ItemController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public ItemController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion


        #region InsertItem
        [HttpPost("InsertItem.{format}"), FormatFilter]
        public async Task<IActionResult> InsertItem([FromBody] List<ItemRequest> obj)
        {
            try
            {
                var client = new HttpClient();

                var baseAddress = new Uri(_dbOption.BaseAddress);
                client.Timeout = TimeSpan.FromMinutes(5);

                byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                var request = new HttpRequestMessage(HttpMethod.Post, "http://10.201.206.47:7014/api/erp/v1/scm/item-insert");


                request.Headers.Authorization = new BasicAuthenticationHeaderValue("oracleErp", "123");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));

                var postObject = JsonConvert.SerializeObject(obj);

                request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);

                var response = await client.SendAsync(request);

                string stringData = await response.Content.ReadAsStringAsync();

                //var data = JsonConvert.DeserializeObject<ItemResponse>(stringData);

                var data = JsonConvert.DeserializeObject<List<ItemResponse>>(stringData);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion


        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            // HttpContext.Response.ContentType = "application/json";
            HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return StatusCode(HttpContext.Response.StatusCode, JsonConvert.SerializeObject(new
            {
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}
