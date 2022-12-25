using elevatus_out.Vacant;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace elevatus_out.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [FormatFilter]
    public class VacantController : ControllerBase
    {
        #region Field
        private readonly DBOption _dbOption;
        public VacantController(DBOption dbOption)
        {
            _dbOption = dbOption;
        }
        #endregion

        #region GetVacant
        [HttpPost("GetVacants.{format}"), FormatFilter]
        public async Task<IActionResult> GetVacants(int limit = 30, int page = 1, [FromBody] GetVacantRequest obj = null)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    var request = new HttpRequestMessage(HttpMethod.Get, baseAddress + "/api/v1/service/vacant?limit=" + limit + "&page=" + page);
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<GetVacantResponse>(stringData);
                    return Ok(data.IntegrateAccount.ExtraData);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region UpdateVacant
        [HttpPost("UpdateVacant.{format}"), FormatFilter]
        public async Task<IActionResult> UpdateVacant([FromBody] List<VacantRequestObj> obj)
        {
            try
            {
                List<VacantRequest> objList = new List<VacantRequest>();
                RemappingNewObject(obj, objList);
                List<ExtraDataUpdateVacant> result = new List<ExtraDataUpdateVacant>();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Put, baseAddress + "api/v1/service/vacant");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(objList);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<UpdateVacantResponse>(stringData);
                    foreach (var item in data.IntegrateAccount.ExtraData)
                    {
                        item.requestId = data.Identifiers.RequestId;
                    }
                    result = data.IntegrateAccount.ExtraData;
                    //var issues = JsonConvert.SerializeObject(data.Reason).Replace("\"", "");
                    //issues = issues.Replace(":", " ").Replace(",", " ");
                    //result.Message = data.Identifiers.Status == "success" ? "Updated Vacant Successfully" : issues;
                    //result.Status = data.Identifiers.Status;
                    //result.RequestId = data.Identifiers.RequestId;
                    //result.Reasons = JsonConvert.SerializeObject(data.Reason).ToString();
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }

        private static void RemappingNewObject(List<VacantRequestObj> obj, List<VacantRequest> objList)
        {
            foreach (var item in obj)
            {
                VacantRequest newObj = new VacantRequest();
                newObj.oracle_id = item.oracle_id;
                newObj.system_position_id = item.system_position_id;
                newObj.system_branch_id = item.system_branch_id;
                newObj.system_overlap_start = item.system_overlap_start;
                newObj.system_overlap_end_date = item.system_overlap_end_date;
                newObj.system_number_ocp = item.system_number_ocp;
                newObj.system_new_position = item.system_new_position;
                newObj.system_number_ocpbfp = item.system_number_ocpbfp;
                newObj.system_number_ocpbft = item.system_number_ocpbft;
                newObj.system_number_ocpbft = item.system_number_ocpbft;
                newObj.num_of_requisition = item.num_of_requisition;
                newObj.employee_person_id = !String.IsNullOrEmpty(item.employee_person_id) ? item.employee_person_id.Split(',') : null;
                objList.Add(newObj);
            }
        }
        #endregion

        #region DeleteVacant
        [HttpPost("DeleteVacant.{format}"), FormatFilter]
        public async Task<IActionResult> DeleteVacant([FromBody] List<DeleteVacantRequest> obj)
        {
            try
            {
                List<ExtraDeleteVacantResponse> result = new List<ExtraDeleteVacantResponse>();
                using (var client = new HttpClient())
                {
                    var baseAddress = new Uri(_dbOption.BaseAddress);
                    client.Timeout = TimeSpan.FromMinutes(5);
                    byte[] cred = Encoding.UTF8.GetBytes(_dbOption.UserName + ":" + _dbOption.Password);
                    var request = new HttpRequestMessage(HttpMethod.Delete, baseAddress + "api/v1/service/vacant");
                    request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(cred));
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(_dbOption.JsonFormat));
                    var postObject = JsonConvert.SerializeObject(obj);
                    request.Content = new StringContent(postObject, Encoding.UTF8, "application/json");
                    request.Content.Headers.ContentType = new MediaTypeHeaderValue(_dbOption.JsonFormat);
                    var response = await client.SendAsync(request);
                    string stringData = await response.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<DeleteVacantResponse>(stringData);
                    foreach (var item in data.IntegrateAccount.ExtraData)
                    {
                        item.requestId = data.Identifiers.RequestId;
                    }
                    result = data.IntegrateAccount.ExtraData;

                    return Ok(result);
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
                    message = ex.ToString(),
                    exception = ex.GetType().Name
                }
            }));
        }
        #endregion
    }
}