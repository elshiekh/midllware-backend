using APIMiddleware.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IRequestService
    {
        bool AddRequest(RequestDTO requestDTO);
        bool RemoveRequest(int id);
        Task<List<RequestDTO>> GetAllRequests();
        Task<List<RequestDTO>> GetAllWithFilter(int? projectId
            ,string function, int? statusCode,int? requestReceiveId,
             string ipAddress,string userName,string fromDate, string toDate);
        Task<int> GetAllRequestCounts();
        Task<RequestDTO> GetRequestsDetails(int id);
    }
}
