using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Extenstion;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APIMiddleware.Core
{
    public class ApiLogging
    {
        private readonly RequestDelegate _next;
        private readonly IRequestService _requestService;
        private readonly WebAPIProject _options;

        public ApiLogging(RequestDelegate next, IRequestService requestService, WebAPIProject options)
        {
            _next = next;
            _requestService = requestService;
            _options = options;
        }

        public async Task Invoke(HttpContext httpContext, IRequestService requestService)
        {
            try
            {
                await RegisterRequest(httpContext);
            }
            catch (Exception ex)
            {
                await _next(httpContext);
            }
        }

        private async Task RegisterRequest(HttpContext httpContext)
        {
            using (var responseBody = new MemoryStream())
            {
                var webAPIName = _options.Name;
                var ProjectUserName = _options.UserName;
                var stopWatch = Stopwatch.StartNew();
                var requestTime = DateTime.UtcNow;
                var request = httpContext.Request;
                var requestBodyContent = await ReadRequestBody(request);
                var originalBodyStream = httpContext.Response.Body;
                var host = httpContext.Connection.RemoteIpAddress;
                var response = httpContext.Response;
                response.Body = responseBody;

                await _next(httpContext);
                stopWatch.Stop();

                string responseBodyContent = await ReadResponseBody(response);
                await responseBody.CopyToAsync(originalBodyStream);
                var requestContentType = httpContext.Request.ContentType;
                var responseContentType = httpContext.Response.ContentType;

                _requestService.AddRequest(new DTO.RequestDTO()
                {
                    ProjectCode = _options.Id,
                    RequestGuid = Guid.NewGuid().ToString(),
                    RequestTime = requestTime,
                    ElapsedMilliseconds = stopWatch.ElapsedMilliseconds,
                    ResponseStatus = response.StatusCode,
                    RequestMethod = request.Method,
                    RequestUrl = request.Path,
                    RequestFunction = QueryExtenstion.GetFileNameFromUrl(request.Path),
                    IP_Address = host.ToString(),
                    QueryString = request.QueryString.ToString(),
                    RequestBody = JsonStringToByteArray(requestBodyContent),
                    ResponseBody = JsonStringToByteArray(responseBodyContent),
                    RequestFormat = requestContentType,
                    ResponseFormat = responseContentType,
                    UserName = ProjectUserName,
                    RowVersion = DateTime.Now.ToString()
                });
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await response.WriteAsync(JsonConvert.SerializeObject(new
            {
                // customize as you need
                error = new
                {
                    message = ex.Message,
                    exception = ex.GetType().Name
                }
            }));
        }

        private async Task<string> ReadRequestBody(HttpRequest request)
        {
            try
            {
                var buffer = new byte[Convert.ToInt32(request.ContentLength)];
                await request.Body.ReadAsync(buffer, 0, buffer.Length);
                var bodyAsText = Encoding.UTF8.GetString(buffer);
                request.Body.Seek(0, SeekOrigin.Begin);

                return bodyAsText;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private async Task<string> ReadResponseBody(HttpResponse response)
        {
            try
            {
                response.Body.Seek(0, SeekOrigin.Begin);
                var bodyAsText = await new StreamReader(response.Body).ReadToEndAsync();
                response.Body.Seek(0, SeekOrigin.Begin);

                return bodyAsText;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] JsonStringToByteArray(string jsonByteString)
        {
            try
            {
                // Convert a C# string to a byte array  
                return Encoding.ASCII.GetBytes(jsonByteString);
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public string ByteArrayToJsonString(byte[] bytes)
        {
            try
            {
                // Convert a C# string to a byte array  
                return Encoding.ASCII.GetString(bytes);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
