using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Faces;

namespace WebApp.Services
{
    public interface IFaceService
    {
        Task<bool> Create(FaceCreateRequest request);
        Task<bool> Delete(int faceId);
        Task<List<FaceViewModel>> GetAll();
        
        Task<FaceUpdateRequest> GetById(int faceId);

        Task<bool> Update(int faceId, FaceUpdateRequest request);
    }
}