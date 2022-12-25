using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Filter;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IRequestService
    {
        bool AddRequest(RequestDTO requestDTO);
        bool RemoveRequest(int id);
        Task<List<RequestDTO>> GetAllRequests();
        Task<List<RequestDTO>> GetRequests(PaginationFilter filter, int? projectId
        , string function, int? statusCode, int? requestReceiveId,
        string ipAddress, string userName, string fromDate, string toDate);
        Task<List<RequestDTO>> GetAllWithFilter(int? requestId, int? projectId
        , int? function, int? responseCode, string requestStatus,
         string ipAddress, string userName, string fromDate, string toDate);
        bool PurgeAllWithFilter(int? requestId, int? projectId
        , int? function, int? responseCode, string requestStatus,
        string ipAddress, string userName, string fromDate, string toDate);
        Task<int> GetAllRequestCounts();
        Task<RequestDTO> GetRequestsDetails(int id);
    }
}
