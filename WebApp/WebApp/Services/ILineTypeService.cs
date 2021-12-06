using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.LineTypeOptions;
using WebApp.ViewModels.LineTypes;

namespace WebApp.Services
{
    public interface ILineTypeService
    {
        Task<bool> Create(LineTypeCreateRequest request);
        Task<bool> Delete(int lineTypeId);
        Task<List<LineTypeViewModel>> GetAll();
        Task<LineTypeCreateRequest> GetById(int lineTypeId);
        Task<LineTypeCreateRequest> GetFirstLineType();
        Task<List<LineTypeOptionViewModel>> GetLineTypeOptionByLineTypeId(int faceTypeId);
        Task<bool> Update(int lineTypeId, LineTypeCreateRequest request);
    }
}