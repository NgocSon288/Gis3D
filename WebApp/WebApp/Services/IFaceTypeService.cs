using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.FaceTypeOptions;
using WebApp.ViewModels.FaceTypes;

namespace WebApp.Services
{
    public interface IFaceTypeService
    {
        Task<bool> Create(FaceTypeCreateRequest request);
        Task<bool> Delete(int lineTypeId);
        Task<List<FaceTypeViewModel>> GetAll();
        Task<FaceTypeCreateRequest> GetById(int lineTypeId);
        Task<List<FaceTypeOptionViewModel>> GetFaceTypeOptionByFaceTypeId(int faceTypeId);
        Task<FaceTypeCreateRequest> GetFirstFaceType();
        Task<bool> Update(int lineTypeId, FaceTypeCreateRequest request);
    }
}