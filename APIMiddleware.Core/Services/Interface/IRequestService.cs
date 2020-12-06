using APIMiddleware.Core.DTO;
using System.Collections.Generic;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IRequestService
    {
        bool AddRequest(RequestDTO requestDTO);
        bool RemoveRequest(int id);
        List<RequestDTO> GetAllRequests();
        RequestDTO GetRequestsDetails(int id);
    }
}
