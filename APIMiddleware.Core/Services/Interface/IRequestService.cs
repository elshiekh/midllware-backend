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
        Task<int> GetAllRequestCounts();
        RequestDTO GetRequestsDetails(int id);
    }
}
