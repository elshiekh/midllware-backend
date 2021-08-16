using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.Entities;
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

        public bool AddProject(ProjectDTO projectDTO)
        {
            try
            {
                _dbContext.Add(new Project()
                {
                    ProjectName = projectDTO.ProjectName,
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
                var project = _dbContext.Projects.FirstOrDefault(s => s.ProjectId == id);
                _dbContext.Remove(project);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ProjectDTO>> GetAllProjects()
        {
            try
            {
              var projects =  await _dbContext.Projects.ToListAsync();
                return projects.Select(project => new ProjectDTO
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    ProjectCode = project.ProjectCode,
                    Functions = GetProjectFunctions(project.ProjectId),
                    Description = project.Description,
                    EnabledFlag = project.EnabledFlag,
                    RowVersion = project.RowVersion,
                    CREATED_BY = project.CREATED_BY,
                    LAST_UPDATED_BY = project.LAST_UPDATED_BY,
                    CREATION_DATE = project.CREATION_DATE,
                    LAST_UPDATE_DATE = project.LAST_UPDATE_DATE
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FunctionDTO> GetProjectFunctions(int projectId)
        {
            try
            {
                var functions = _dbContext.Functions.Where(x=>x.ProjectId == projectId).Include(x => x.Project);
                return  functions.Select(function => new FunctionDTO
                {
                    FunctionId = function.FunctionId,
                    FunctionName = function.FunctionName,
                    FunctionCode = function.FunctionCode,
                    ProjectId = function.ProjectId,
                    ProjectName = function.Project.ProjectName,
                    Description = function.Description,
                    EnabledFlag = function.EnabledFlag,
                    CREATED_BY = function.CREATED_BY,
                    LAST_UPDATED_BY = function.LAST_UPDATED_BY,
                    CREATION_DATE = function.CREATION_DATE,
                    LAST_UPDATE_DATE = function.LAST_UPDATE_DATE
                }).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
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
                var project = await _dbContext.Projects.FirstOrDefaultAsync(s => s.ProjectId == id);

                return new ProjectDTO()
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
     
    }
}
