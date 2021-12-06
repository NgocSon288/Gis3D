using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.EF;
using WebApp.ViewModels.Options;

namespace WebApp.Services
{
    public class OptionService : IOptionService
    {
        private readonly ApplicationDbContext _context;

        public OptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OptionViewModel>> GetAll()
        {
            return await _context.Options
                .Select(x => new OptionViewModel()
                {
                    Id = x.Id,
                    IsNumber = x.IsNumber,
                    Name = x.Name
                }).ToListAsync();
        }
    }
}
