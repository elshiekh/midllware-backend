//using ConsumeProductService;
//using DeactivationCancelProductService;
//using Microsoft.AspNetCore.Mvc;
//using ProductConsumeCancelService;
//using ProductDeactivationService;
//using ProductDispatchCancelService;
//using ProductDispatchService;
//using ProductExportCancelService;
//using ProductExportService;
//using ProductImportCancelService;
//using ProductImportService;
//using ProductReturnService;
//using ProductTransferCancelService;
//using ProductTransferService;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace SFDA.Controllers
//{
//    [ApiController]
//    [ApiExplorerSettings(IgnoreApi = true)]
//    public class ProductController : ControllerBase
//    {
//        //[HttpPost("api/SFDA/Deactivate.{format}"), FormatFilter]
//        //public async Task<deactivationServiceResponse> ProductDeactivation([FromBody] deactivationServiceRequest request, string gln)
//        //{
//        //    try
//        //    {
//        //        DeactivationServiceClient client = new DeactivationServiceClient();
//        //        var postRequest = new notifyDeactivationRequest() { DeactivationServiceRequest = request };
//        //        client.ClientCredentials.UserName.UserName = gln + "0000";
//        //        client.ClientCredentials.UserName.Password = "Ahmad123456";
//        //        var result = await client.notifyDeactivationAsync(postRequest);

//        //        return result.DeactivationServiceResponse;
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        throw ex;
//        //    }
//        //}


//        [HttpPost("api/SFDA/CancelDeactivate/.{format}"), FormatFilter]
//        public async Task<deactivationCancelServiceResponse> CancelDeactivation([FromBody] deactivationCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                DeactivationCancelServiceClient client = new DeactivationCancelServiceClient();
//                var postRequest = new notifyDeactivationCancelRequest() { DeactivationCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyDeactivationCancelAsync(postRequest);

//                return result.DeactivationCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        [HttpPost("api/SFDA/Consume/.{format}"), FormatFilter]
//        public async Task<consumeServiceResponse> Consume([FromBody] consumeServiceRequest request, string gln)
//        {
//            try
//            {
//                ConsumeServiceClient client = new ConsumeServiceClient();
//                var postRequest = new notifyConsumeRequest() { ConsumeServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyConsumeAsync(postRequest);

//                return result.ConsumeServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }


//        [HttpPost("api/SFDA/CancelConsume/.{format}"), FormatFilter]
//        public async Task<consumeCancelServiceResponse> CancelConsume([FromBody] consumeCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                ConsumeCancelServiceClient client = new ConsumeCancelServiceClient();
//                var postRequest = new notifyConsumeCancelRequest() { ConsumeCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyConsumeCancelAsync(postRequest);

//                return result.ConsumeCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/Transfer/.{format}"), FormatFilter]
//        public async Task<transferServiceResponse> TransferCancel([FromBody] transferServiceRequest request, string gln)
//        {
//            try
//            {
//                TransferServiceClient client = new TransferServiceClient();
//                var postRequest = new notifyTransferRequest() { TransferServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyTransferAsync(postRequest);

//                return result.TransferServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/GenerateObjTransferServiceRequest/.{format}"), FormatFilter]
//        public async Task<IActionResult> GenerateObjTransferServiceRequest()
//        {
//            try
//            {
//                transferServiceRequest sss = new transferServiceRequest();
//                sss.TOGLN = "asdsadasd";

//                List<ProductTransferService.product> products = new List<ProductTransferService.product>();
//                ProductTransferService.product product1 = new ProductTransferService.product
//                {
//                    BN = "12",
//                    GTIN = "333",
//                    SN = "123",
//                    XD = DateTime.Now,
//                    XDSpecified = true,
//                };
//                products.Add(product1);


//                sss.PRODUCTLIST = products.ToArray();


//                return Ok(sss);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/TransferCancel/.{format}"), FormatFilter]
//        public async Task<transferCancelServiceResponse> TransferCancel([FromBody] transferCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                TransferCancelServiceClient client = new TransferCancelServiceClient();
//                var postRequest = new notifyTransferCancelRequest() { TransferCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyTransferCancelAsync(postRequest);

//                return result.TransferCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/Return/.{format}"), FormatFilter]
//        public async Task<returnServiceResponse> Return([FromBody] returnServiceRequest request, string gln)
//        {
//            try
//            {
//                ReturnServiceClient client = new ReturnServiceClient();
//                var postRequest = new notifyReturnRequest() { ReturnServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyReturnAsync(postRequest);

//                return result.ReturnServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/Dispatch/.{format}"), FormatFilter]
//        public async Task<dispatchServiceResponse> Dispatch([FromBody] dispatchServiceRequest request, string gln)
//        {
//            try
//            {
//                DispatchServiceClient client = new DispatchServiceClient();
//                var postRequest = new notifyDispatchRequest() { DispatchServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyDispatchAsync(postRequest);

//                return result.DispatchServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/DispatchCancel/.{format}"), FormatFilter]
//        public async Task<dispatchCancelServiceResponse> DispatchCancel([FromBody] dispatchCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                DispatchCancelServiceClient client = new DispatchCancelServiceClient();
//                var postRequest = new notifyDispatchCancelRequest() { DispatchCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyDispatchCancelAsync(postRequest);

//                return result.DispatchCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/Export/.{format}"), FormatFilter]
//        public async Task<exportServiceResponse> Export([FromBody] exportServiceRequest request, string gln)
//        {
//            try
//            {
//                ExportServiceClient client = new ExportServiceClient();
//                var postRequest = new ProductExportService.notifyExportRequest() { ExportServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyExportAsync(postRequest);

//                return result.ExportServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/ExportCancel/.{format}"), FormatFilter]
//        public async Task<exportCancelServiceResponse> ExportCancel([FromBody] exportCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                ExportCancelServiceClient client = new ExportCancelServiceClient();
//                var postRequest = new ProductExportCancelService.notifyExportRequest() { ExportCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyExportAsync(postRequest);

//                return result.ExportCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/Import/.{format}"), FormatFilter]
//        public async Task<importServiceResponse> Import([FromBody] importServiceRequest request, string gln)
//        {
//            try
//            {
//                ImportServiceClient client = new ImportServiceClient();
//                var postRequest = new ProductImportService.notifyImportRequest() { ImportServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyImportAsync(postRequest);

//                return result.ImportServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }

//        [HttpPost("api/SFDA/ImportCancel/.{format}"), FormatFilter]
//        public async Task<importCancelServiceResponse> ImportCancel([FromBody] importCancelServiceRequest request, string gln)
//        {
//            try
//            {
//                ImportCancelServiceClient client = new ImportCancelServiceClient();
//                var postRequest = new ProductImportCancelService.notifyImportCancelRequest() { ImportCancelServiceRequest = request };
//                client.ClientCredentials.UserName.UserName = gln + "0000";
//                client.ClientCredentials.UserName.Password = "Ahmad123456";
//                var result = await client.notifyImportCancelAsync(postRequest);

//                return result.ImportCancelServiceResponse;
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//        }
//    }
//}