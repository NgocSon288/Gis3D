using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Commons;

namespace WebApp.Services
{
    public class BaseService
    {

        private readonly IConfiguration _configuration;

        public BaseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetOwner()
        {
            return _configuration.GetValue<string>(SystemConstants.Owner);
        }
    }
}
