using AcceptDispatchPackageService;
using AcceptProductService;
using CheckStatusCodeService;
using CityService;
using CountryService;
using DrugService;
using ErrorCodeService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pharmacy_SaleService;
using PharmacyProductSaleCancelService;
using ProductPackageDownloadService;
using ProductPackageUploadService;
using QueryPackageService;
using SFDA.DTO;
using SFDA.Extenstion;
using StakeholderList;
using System;
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

        #region GetCountryList
        [HttpPost("api/SFDA/GetCountryList.{format}"), FormatFilter]
        public async Task<countryListServiceResponse> GetCountryList([FromBody] countryListServiceRequest request, string gln)
        {
            try
            {
                CountryListServiceClient client = new CountryListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCountryListAsync(request);

                return result.CountryListServiceResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region  GetCityList
          [HttpPost("api/SFDA/GetCityList.{format}"), FormatFilter]
          public async Task<cityListServiceResponse> GetCityList([FromBody] cityListServiceRequest request, string gln)
        {
            try
            {
                CityListServiceClient client = new CityListServiceClient();
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getCityListAsync(request);

                return result.CityListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  GetDrugList
           [HttpPost("api/SFDA/GetDrugList.{format}"), FormatFilter]
           public async Task<drugListServiceResponse> GetDrugList([FromBody] drugListServiceRequest request, string gln)
        {
            try
            {
                DrugListServiceClient client = new DrugListServiceClient();
                var requestedPost = new getDrugListRequest(request);
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getDrugListAsync(requestedPost);

                return result.DrugListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
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
                var postRequest = new  AcceptProductService.notifyAcceptRequest() { AcceptServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyAcceptAsync(postRequest);

                return Ok(result.AcceptServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region AcceptDispatch
        [HttpPost("api/SFDA/AcceptDispatch.{format}"), FormatFilter]
        public async Task<IActionResult> AcceptDispatch([FromBody] acceptDispatchServiceRequest request, string gln)
        {
            try
            {
                AcceptDispatchServiceClient client = new AcceptDispatchServiceClient();
                var postRequest = new AcceptDispatchPackageService.notifyAcceptRequest() { AcceptDispatchServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyAcceptAsync(postRequest);

                return Ok(result.AcceptDispatchServiceResponse);
            }
            catch (Exception ex)
            {
                throw ex;
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
                throw ex;
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
                throw ex;
            }
        }
        #endregion

        #region PharmacySale
        [HttpPost("api/SFDA/PharmacySale.{format}"), FormatFilter]
        public async Task<pharmacySaleServiceResponse> PharmacySaleCancel([FromBody] pharmacySaleServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleServiceClient client = new PharmacySaleServiceClient();
                var postRequest = new notifyPharmacySaleRequest { PharmacySaleServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleAsync(postRequest);

                return result.PharmacySaleServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region  PharmacySaleCancel
        [HttpPost("api/SFDA/PharmacySaleCancel.{format}"), FormatFilter]
        public async Task<pharmacySaleCancelServiceResponse> PharmacySaleCancel([FromBody] pharmacySaleCancelServiceRequest request, string gln)
        {
            try
            {
                PharmacySaleCancelServiceClient client = new PharmacySaleCancelServiceClient();
                var postRequest = new notifyPharmacySaleCancelRequest { PharmacySaleCancelServiceRequest = request };
                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.notifyPharmacySaleCancelAsync(postRequest);

                return result.PharmacySaleCancelServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetStakeHolderList
        [HttpPost("api/SFDA/GetStakeHolderList.{format}"), FormatFilter]
        public async Task<stakeholderListServiceResponse> GetStakeHolderList([FromBody] stakeholderListServiceRequest request, string gln)
        {
            try
            {
                StakeholderListServiceClient client = new StakeholderListServiceClient();

                client.ClientCredentials.UserName.UserName = gln + "0000";
                client.ClientCredentials.UserName.Password = "Ahmad123456";
                var result = await client.getStakeholderListAsync(request);

                return result.StakeholderListServiceResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
