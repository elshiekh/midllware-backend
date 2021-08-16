using APIMiddleware.Core.DTO;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IDashBoardService
    {
        DashBoardDTO  GetDashBoardDetails();
    }
}
