using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Points;

namespace WebApp.Services
{
    public interface IPointService
    {
        Task<bool> Create(PointCreateRequest request);
        Task<bool> Delete(int pointId);
        Task<List<PointViewModel>> GetAll();
        Task<PointUpdateRequest> GetById(int pointId);
        Task<bool> Update(int pointId, PointUpdateRequest request);
    }
}