using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.PointTypeOptions;
using WebApp.ViewModels.PointTypes;

namespace WebApp.Services
{
    public interface IPointTypeService
    {
        Task<bool> Create(PointTypeCreateRequest request);
        Task<bool> Delete(int pointTypeId);
        Task<List<PointTypeViewModel>> GetAll();
        Task<PointTypeCreateRequest> GetById(int pointTypeId);
        Task<PointTypeCreateRequest> GetFirstPointType();
        Task<List<PointTypeOptionViewModel>> GetPointTypeOptionByPointTypeId(int pointTypeId);
        Task<bool> Update(int pointTypeId, PointTypeCreateRequest request);
    }
}