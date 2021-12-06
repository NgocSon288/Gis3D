using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;

namespace WebApp.ViewModels.Bodies
{
    public class BodyRequest
    {
        public LOD Lod { get; set; }

        public List<int> BodyId { get; set; }
    }
}
