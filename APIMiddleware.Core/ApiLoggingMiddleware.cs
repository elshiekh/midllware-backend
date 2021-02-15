using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
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
                var request = httpContext.Request;
                var stopWatch = Stopwatch.StartNew();
                var requestTime = DateTime.UtcNow;
                var requestBodyContent = await ReadRequestBody(request);
                var originalBodyStream = httpContext.Response.Body;

                var webAPIName = _options.Name;

                using (var responseBody = new MemoryStream())
                {
                    var response = httpContext.Response;
                    response.Body = responseBody;
                    await _next(httpContext);
                    stopWatch.Stop();

                    string responseBodyContent = await ReadResponseBody(response);
                    await responseBody.CopyToAsync(originalBodyStream);

                    var host = httpContext.Request.Host;
                    var requestContentType = httpContext.Request.ContentType;
                    var responseContentType = httpContext.Response.ContentType;
                    _requestService.AddRequest(new DTO.RequestDTO()
                    {
                        ProjectCode = _options.Id,
                        RequestGuid = Guid.NewGuid().ToString(),
                        RequestTime = requestTime,
                        ElapsedMilliseconds = stopWatch.ElapsedMilliseconds,
                        StatusCode = response.StatusCode,
                        Method = request.Method,
                        Path = request.Path,
                        Host = host.ToString(),
                        QueryString = request.QueryString.ToString(),
                        RequestBody = JsonStringToByteArray(requestBodyContent),
                        ResponseBody = JsonStringToByteArray(responseBodyContent),
                        RequestExtension = requestContentType,
                        ResponseExtension = responseContentType
                    });;
                }
            }
            catch (Exception ex)
            {
                await _next(httpContext);
            }
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
            catch (Exception e)
            {
                throw;
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
