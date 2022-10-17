using APIMiddleware.Core.DBContext;
using APIMiddleware.Core.DTO;
using APIMiddleware.Core.Enum;
using APIMiddleware.Core.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace APIMiddleware.Core.Services.Implementation
{
    public class DashBoardService : IDashBoardService
    {
        private readonly APIMiddlewareContext _dbContext;

        public DashBoardService()
        {
            _dbContext = new APIMiddlewareContext();
        }

        public DashBoardDTO GetDashBoardDetails()
        {
            try
            {
                var dashboardDetails = _dbContext.Requests.Include(x => x.Project);
                var model = new DashBoardDTO();
                model.Sfda_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.SFDA).Count();
                model.Sfda_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.SFDA && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Sfda_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.SFDA && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                model.Vida_In_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_IN).Count();
                model.Vida_In_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_IN && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Vida_In_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_IN && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                model.Vida_Out_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_OUT).Count();
                model.Vida_Out_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_OUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Vida_Out_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.VIDA_OUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();


                model.Onbase_In_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_IN).Count();
                model.Onbase_In_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_IN && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Onbase_In_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_IN && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                model.Onbase_Out_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_OUT).Count();
                model.Onbase_Out_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_OUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Onbase_Out_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.ONBASE_OUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                model.Mohemm_Out_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.MOHEMMOUT).Count();
                model.Mohemm_Out_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.MOHEMMOUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Mohemm_Out_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.MOHEMMOUT && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();


                model.External_Portal_In_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.EXTERNALPORTALIN).Count();
                model.External_Portal_In_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.EXTERNALPORTALIN && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.External_Portal_In_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.EXTERNALPORTALIN && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                model.Pormations_Portal_In_Total = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.PROMOTIONSPORTALIN).Count();
                model.Pormations_Portal_In_Success = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.PROMOTIONSPORTALIN && x.ResponseCode == (int)GenericEnum.RequestStatus.Success).Count();
                model.Pormations_Portal_In_Fail = dashboardDetails.Where(x => x.ProjectId == (int)GenericEnum.ProjectCode.PROMOTIONSPORTALIN && x.ResponseCode == (int)GenericEnum.RequestStatus.Fail).Count();

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
