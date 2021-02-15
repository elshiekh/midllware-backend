using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.DBContext.Entities;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Services.Interface;
using APIMiddleware.Notification.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIMiddleware.Core.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly APIMiddlewareContext _dbContext;

        public ProjectService(ISystemPreferenceService systemPreferenceService, IEmailService emailService)
        {
            _dbContext = new APIMiddlewareContext();
        }

        public bool AddProject(ProjectDTO requestDTO)
        {
            try
            {
                _dbContext.Add(new Project()
                {
                    ProjectName = requestDTO.ProjectName,
                });

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveProject(int id)
        {
            try
            {
                var request = _dbContext.Projects.FirstOrDefault(s => s.ProjectId == id);
                _dbContext.Remove(request);

                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task<List<ProjectDTO>> GetAllProjects()
        {
            try
            {
                var requests =  _dbContext.Projects;

                return  await requests.Select(request => new ProjectDTO
                {
                    Id = request.ProjectId,
                    ProjectName = request.ProjectName,
                }).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> GetAllProjectCounts()
        {
            try
            {
                return  await _dbContext.Projects.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ProjectDTO> GetProjectsDetails(int id)
        {
            try
            {
                var request = await _dbContext.Projects.FirstOrDefaultAsync(s => s.ProjectId == id);

                return new ProjectDTO()
                {
                    Id = request.ProjectId,
                    ProjectName = request.ProjectName,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
     
    }
}
