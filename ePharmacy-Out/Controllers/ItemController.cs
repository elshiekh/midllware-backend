﻿using ePharmacy_Out.Item;
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
using ePharmacy_Out.Mapper;

namespace ePharmacy_Out.Controllers
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

        #region GenerateToken
        public static async Task<string> GenerateToken()
        {
            var clientToken = new HttpClient { BaseAddress = new Uri("https://hmgpharmacyapi.hmg.com") };
            var content = new StringContent(JsonConvert.SerializeObject(new { ClientId = "erp_pharmacy", Secret = "7bceeb9674ce613214c0643ae9ac79044b25452792f692ac246ac6bf49e7fea8", grant_type = "client_credentials" }), Encoding.UTF8, "application/json");
            var responseToken = await clientToken.PostAsync("api/token/login_api", content);
            var tokenResponse = await responseToken.Content.ReadAsStringAsync();
            var dataToken = JsonConvert.DeserializeObject<TokenResponse>(tokenResponse);

            return dataToken.auth_token;
        }
        #endregion


        #region CreateItem
        [HttpPost("CreateItem.{format}"), FormatFilter]
        public async Task<IActionResult> CreateItem([FromBody] List<ItemRequest> obj)
        {
            try
            {
                // get cached token
                // check if the token not null
                // call the integration 
                // if integration retrun time out generate new token
                // if it null generate new one
                var token = await GenerateToken();


                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://hmgpharmacyapi.hmg.com/api/product/create_product");

                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));

                    var postObject = JsonConvert.SerializeObject(obj);

                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);

                    var response = await client.SendAsync(request);

                    string stringData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ItemResponse>(stringData);


                    //ObjectToXML
                    var XMLdata = data.ToXMLResponceItem();


                    return Ok(XMLdata);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region UpdateItem
        [HttpPost("UpdateItem.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateItem([FromBody] List<ItemRequest> obj)
        {
            try
            {
                // get cached token
                // check if the token not null
                // call the integration 
                // if integration retrun time out generate new token
                // if it null generate new one
                var token = await GenerateToken();


                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);

                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Post, "https://hmgpharmacyapi.hmg.com/api/product/update_product");

                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));

                    var postObject = JsonConvert.SerializeObject(obj);

                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);

                    var response = await client.SendAsync(request);

                    string stringData = await response.Content.ReadAsStringAsync();

                    var data = JsonConvert.DeserializeObject<ItemResponse>(stringData);


                    //ObjectToXML
                    var XMLdata = data.ToXMLResponceItem();


                    return Ok(XMLdata);
                }
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
