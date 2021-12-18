using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.Bodies;

namespace WebApp.Services
{
    public interface IApiService
    {
        Task<List<BodyViewModel>> ApiGetBodies(); 
        Task<List<BodyViewModel>> ApiGetBodiesGis(BodyRequest request);
        Task<List<BodyViewModel>> ApiGetBodiesGis2(BodyRequest request);
        List<LOD> ApiGetLods();
    }
}