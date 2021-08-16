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
    public class FunctionService : IFunctionService
    {
        private readonly APIMiddlewareContext _dbContext;

        public FunctionService(ISystemPreferenceService systemPreferenceService, IEmailService emailService)
        {
            _dbContext = new APIMiddlewareContext();
        }

        public bool AddFunction(FunctionDTO functionDTO)
        {
            try
            {
                _dbContext.Add(new Function()
                {
                    FunctionCode = functionDTO.FunctionCode,
                    FunctionName = functionDTO.FunctionName,
                    ProjectId = functionDTO.ProjectId,
                });

                _dbContext.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveFunction(int id)
        {
            try
            {
                var function = _dbContext.Functions.FirstOrDefault(s => s.FunctionId == id);
                _dbContext.Remove(function);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FunctionDTO>> GetAllFunctions()
        {
            try
            {
                var functions = _dbContext.Functions.Include(x=>x.Project);
                return await functions.Select(function => new FunctionDTO
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
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<FunctionDTO>> GetAllFunctionsByProject(int projectId)
        {
            try
            {
                var functions = _dbContext.Functions.Where(x=>x.ProjectId == projectId).Include(x => x.Project);
                return await functions.Select(function => new FunctionDTO
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
                }).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<int> GetAllFunctionCounts()
        {
            try
            {
                return await _dbContext.Functions.CountAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FunctionDTO> GetFunctionsDetails(int id)
        {
            try
            {
                var function = await _dbContext.Functions.FirstOrDefaultAsync(s => s.FunctionId == id);

                return new FunctionDTO()
                {
                    FunctionId = function.FunctionId,
                    FunctionName = function.FunctionName,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
