using System.Collections.Generic;
using System.Threading.Tasks;
using WebApp.ViewModels.Options;

namespace WebApp.Services
{
    public interface IOptionService
    {
        Task<List<OptionViewModel>> GetAll();
    }
}