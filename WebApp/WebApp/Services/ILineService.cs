using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Lines;

namespace WebApp.Services
{
    public interface ILineService
    {
        Task<bool> Create(LineCreateRequest request);
        Task<bool> Delete(int lineId);
        Task<List<LineViewModel>> GetAll();

        Task<LineUpdateRequest> GetById(int faceId);

        Task<bool> Update(int faceId, LineUpdateRequest request);
    }
}