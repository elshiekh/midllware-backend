using AcceptProductService;
using CheckStatusCodeService;
using CityService;
using ConsumeProductService;
using CountryService;
using DeactivationCancelProductService;
using DeactivationProuctService;
using DrugService;
using ErrorCodeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pharmacy_SaleService;
using PharmacyProductSaleCancelService;
using ProductConsumeCancelService;
using ProductDispatchCancelService;
using ProductDispatchService;
using ProductExportCancelService;
using ProductExportService;
using ProductImportCancelService;
using ProductImportService;
using ProductPackageDownloadService;
using ProductPackageUploadService;
using ProductReturnService;
using ProductTransferCancelService;
using ProductTransferService;
using QueryPackageService;
using SFDA.DTO;
using SFDA.Extenstion;
using StakeholderList;
using System;
using System.Net;
using System.Threading.Tasks;

namespace SFDA.Controllers
{
    [Authorize]
    [ApiController]
    public class SFDAController : ControllerBase
    {
        #region NotifyCheckStatus 
        [HttpPost("api/SFDA/NotifyCheckStatus.{format}"), FormatFilter]
        public async Task<checkStatusServiceResponse> NotifyCheckStatus([FromBody] checkStatusServiceRequest request, string gln)
        {
            try
            {
                CheckStatusServiceClient client = new CheckStatusServiceClient();
                var postRequest = new notifyCheckStatusRequest() { CheckStatusServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyCheckStatusAsync(postRequest);

                return result.CheckStatusServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  GetCityList
        [HttpPost("api/SFDA/GetCityList.{format}"), FormatFilter]
        public async Task<IActionResult> GetCityList([FromBody] cityListServiceRequest request, string gln)
        {
            try
            {
                CityListServiceClient client = new CityListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCityListAsync(request);

                return Ok(result.CityListServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region GetCountryList
        [HttpPost("api/SFDA/GetCountryList.{format}"), FormatFilter]
        public async Task<IActionResult> GetCountryList([FromBody] countryListServiceRequest request, string gln)
        {
            try
            {
                CountryListServiceClient client = new CountryListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCountryListAsync(request);

                return Ok(result.CountryListServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  GetDrugList
        [HttpPost("api/SFDA/GetDrugList.{format}"), FormatFilter]
        public async Task<IActionResult> GetDrugList([FromBody] drugListServiceRequest request, string gln)
        {
            try
            {
                DrugListServiceClient client = new DrugListServiceClient();
                var requestedPost = new getDrugListRequest(request);
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getDrugListAsync(requestedPost);

                return Ok(result.DrugListServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  GetErrorCodeList
        [HttpPost("api/SFDA/GetErrorCodeList.{format}"), FormatFilter]
        public async Task<IActionResult> GetErrorCodeList([FromBody] getErrorCodeListRequest request, string gln)
        {
            try
            {
                ErrorCodeListServiceClient client = new ErrorCodeListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getErrorCodeListAsync(request);

                return Ok(result.ErrorCodeListServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  PackageQuery
        [HttpPost("api/SFDA/PackageQuery.{format}"), FormatFilter]
        public async Task<IActionResult> PackageQuery([FromBody] packageQueryServiceRequest request, string gln)
        {
            try
            {
                PackageQueryServiceClient client = new PackageQueryServiceClient();
                var postRequest = new packageQueryRequest(request);
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.packageQueryAsync(postRequest);

                return Ok(result.PackageQueryServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  Accept
        [HttpPost("api/SFDA/Accept.{format}"), FormatFilter]
        public async Task<IActionResult> Accept([FromBody] acceptServiceRequest request, string gln)
        {
            try
            {
                AcceptServiceClient client = new AcceptServiceClient();
                var postRequest = new AcceptProductService.notifyAcceptRequest() { AcceptServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyAcceptAsync(postRequest);

                return Ok(result.AcceptServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Return
        [HttpPost("api/SFDA/Return.{format}"), FormatFilter]
        public async Task<IActionResult> Return([FromBody] returnServiceRequest request, string gln)
        {
            try
            {
                ReturnServiceClient client = new ReturnServiceClient();
                var postRequest = new notifyReturnRequest() { ReturnServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyReturnAsync(postRequest);

                return Ok(result.ReturnServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  Deactivate
        [HttpPost("api/SFDA/Deactivate.{format}"), FormatFilter]
        public async Task<IActionResult> Deactivate([FromBody] deactivationServiceRequest request, string gln)
        {
            try
            {
                DeactivationServiceClient client = new DeactivationServiceClient();
                //var postRequest = new deactivationServiceRequest() { DeactivationServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyDeactivationAsync(request);

                return Ok(result.DeactivationServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region CancelDeactivation
        [HttpPost("api/SFDA/CancelDeactivate.{format}"), FormatFilter]
        public async Task<IActionResult> CancelDeactivation([FromBody] deactivationCancelServiceRequest request, string gln)
        {
            try
            {
                DeactivationCancelServiceClient client = new DeactivationCancelServiceClient();
                var postRequest = new notifyDeactivationCancelRequest() { DeactivationCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyDeactivationCancelAsync(postRequest);

                return Ok(result.DeactivationCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region PackageDownload
        [HttpPost("api/SFDA/PackageDownload.{format}"), FormatFilter]
        public async Task<IActionResult> PackageDownload([FromBody] packageDownloadServiceRequest request, string gln)
        {
            try
            {
                PackageDownloadServiceClient client = new PackageDownloadServiceClient();
                PackageDownloadResponse response = new PackageDownloadResponse();
                var postRequest = new downloadFileRequest() { PackageDownloadServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.downloadFileAsync(postRequest);

                response.MD5CHECKSUM = result.PackageDownloadServiceResponse.MD5CHECKSUM;
                response.FILES = QueryExtenstion.GetUnCompressedFiles(result.PackageDownloadServiceResponse.FILE);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region PackageUpload
        [HttpPost("api/SFDA/PackageUpload.{format}"), FormatFilter]
        public async Task<IActionResult> PackageUpload([FromBody] packageUploadServiceRequest request, string gln)
        {
            try
            {
                PackageUploadServiceClient client = new PackageUploadServiceClient();
                var postRequest = new uploadFileRequest() { PackageUploadServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.uploadFileAsync(postRequest);

                return Ok(result.PackageUploadServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region PharmacySale
        [HttpPost("api/SFDA/PharmacySale.{format}"), FormatFilter]
        public async Task<IActionResult> PharmacySaleCancel([FromBody] pharmacySaleServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleServiceClient client = new PharmacySaleServiceClient();
                var postRequest = new notifyPharmacySaleRequest { PharmacySaleServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleAsync(postRequest);

                return Ok(result.PharmacySaleServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region  PharmacySaleCancel
        [HttpPost("api/SFDA/PharmacySaleCancel.{format}"), FormatFilter]
        public async Task<IActionResult> PharmacySaleCancel([FromBody] pharmacySaleCancelServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleCancelServiceClient client = new PharmacySaleCancelServiceClient();
                var postRequest = new notifyPharmacySaleCancelRequest { PharmacySaleCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleCancelAsync(postRequest);

                return Ok(result.PharmacySaleCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region GetStakeHolderList
        [HttpPost("api/SFDA/GetStakeHolderList.{format}"), FormatFilter]
        public async Task<IActionResult> GetStakeHolderList([FromBody] stakeholderListServiceRequest request, string gln)
        {
            try
            {
                StakeholderListServiceClient client = new StakeholderListServiceClient();

                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getStakeholderListAsync(request);

                return Ok(result.StakeholderListServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        // ---------------------------------------
        #region  Transfer
        [HttpPost("api/SFDA/Transfer.{format}"), FormatFilter]
        public async Task<IActionResult> Transfer([FromBody] transferServiceRequest request, string gln)
        {
            try
            {
                TransferServiceClient client = new TransferServiceClient();
                var postRequest = new notifyTransferRequest() { TransferServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyTransferAsync(postRequest);

                return Ok(result.TransferServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region TransferCancel

        [HttpPost("api/SFDA/TransferCancel.{format}"), FormatFilter]
        public async Task<IActionResult> TransferCancel([FromBody] transferCancelServiceRequest request, string gln)
        {
            try
            {
                TransferCancelServiceClient client = new TransferCancelServiceClient();
                var postRequest = new notifyTransferCancelRequest() { TransferCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyTransferCancelAsync(postRequest);

                return Ok(result.TransferCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Consume
        [HttpPost("api/SFDA/Consume.{format}"), FormatFilter]
        public async Task<IActionResult> Consume([FromBody] consumeServiceRequest request, string gln)
        {
            try
            {
                ConsumeServiceClient client = new ConsumeServiceClient();
                var postRequest = new notifyConsumeRequest() { ConsumeServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyConsumeAsync(postRequest);

                return Ok(result.ConsumeServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Consume Cancel 
        [HttpPost("api/SFDA/CancelConsume.{format}"), FormatFilter]
        public async Task<IActionResult> CancelConsume([FromBody] consumeCancelServiceRequest request, string gln)
        {
            try
            {
                ConsumeCancelServiceClient client = new ConsumeCancelServiceClient();
                var postRequest = new notifyConsumeCancelRequest() { ConsumeCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyConsumeCancelAsync(postRequest);

                return Ok(result.ConsumeCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Dispatch
        [HttpPost("api/SFDA/Dispatch.{format}"), FormatFilter]
        public async Task<IActionResult> Dispatch([FromBody] dispatchServiceRequest request, string gln)
        {
            try
            {
                DispatchServiceClient client = new DispatchServiceClient();
                var postRequest = new notifyDispatchRequest() { DispatchServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyDispatchAsync(postRequest);

                return Ok(result.DispatchServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region DispatchCancel
        [HttpPost("api/SFDA/DispatchCancel.{format}"), FormatFilter]
        public async Task<IActionResult> DispatchCancel([FromBody] dispatchCancelServiceRequest request, string gln)
        {
            try
            {
                DispatchCancelServiceClient client = new DispatchCancelServiceClient();
                var postRequest = new notifyDispatchCancelRequest() { DispatchCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyDispatchCancelAsync(postRequest);

                return Ok(result.DispatchCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Export
        [HttpPost("api/SFDA/Export.{format}"), FormatFilter]
        public async Task<IActionResult> Export([FromBody] exportServiceRequest request, string gln)
        {
            try
            {
                ExportServiceClient client = new ExportServiceClient();
                var postRequest = new ProductExportService.notifyExportRequest() { ExportServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyExportAsync(postRequest);

                return Ok(result.ExportServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ExportCancel
        [HttpPost("api/SFDA/ExportCancel.{format}"), FormatFilter]
        public async Task<IActionResult> ExportCancel([FromBody] exportCancelServiceRequest request, string gln)
        {
            try
            {
                ExportCancelServiceClient client = new ExportCancelServiceClient();
                var postRequest = new ProductExportCancelService.notifyExportRequest() { ExportCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyExportAsync(postRequest);

                return Ok(result.ExportCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region Import
        [HttpPost("api/SFDA/Import.{format}"), FormatFilter]
        public async Task<IActionResult> Import([FromBody] importServiceRequest request, string gln)
        {
            try
            {
                ImportServiceClient client = new ImportServiceClient();
                var postRequest = new notifyImportRequest() { ImportServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyImportAsync(postRequest);

                return Ok(result.ImportServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion

        #region ImportCancel
        [HttpPost("api/SFDA/ImportCancel.{format}"), FormatFilter]
        public async Task<IActionResult> ImportCancel([FromBody] importCancelServiceRequest request, string gln)
        {
            try
            {
                ImportCancelServiceClient client = new ImportCancelServiceClient();
                var postRequest = new notifyImportCancelRequest() { ImportCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyImportCancelAsync(postRequest);

                return Ok(result.ImportCancelServiceResponse);
            }
            catch (Exception ex)
            {
                return ReturnException(ex);
            }
        }
        #endregion
        // --------------------------
        #region Return Exception
        private IActionResult ReturnException(Exception ex)
        {
            HttpContext.Response.ContentType = "application/json";
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


