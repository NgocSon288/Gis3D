using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Bodies;

namespace WebApp.Services
{
    public interface IBodyService
    { 
        Task<bool> Create(BodyCreateRequest request);
        Task<bool> Delete(int bodyId);
        Task<List<BodyViewModel>> GetAll();
        Task<BodyUpdateRequest> GetById(int bodyId);
        Task<bool> Update(int bodyId, BodyUpdateRequest request);
    }
}