using APIMiddleware.Core.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Interface
{
    public interface IProjectService
    {
        bool AddProject(ProjectDTO requestDTO);
        bool RemoveProject(int id);
        Task<List<ProjectDTO>> GetAllProjects();
        Task<int> GetAllProjectCounts();
        Task<ProjectDTO> GetProjectsDetails(int id);
    }
}
