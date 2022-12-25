using APIMiddleware.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IFunctionService
    {
        bool AddFunction(FunctionDTO requestDTO);
        bool RemoveFunction(int id);
        Task<List<FunctionDTO>> GetAllFunctions();
        Task<List<FunctionDTO>> GetAllFunctionsByProject(int projectId);
        Task<int> GetAllFunctionCounts();
        Task<FunctionDTO> GetFunctionsDetails(int id);
    }
}
