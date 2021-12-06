using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;

namespace WebApp.ViewModels.Points
{
    public class PointSearchForm
    {
        public int? PointTypeId { get; set; }

        public int? BodyId { get; set; }

        public LOD? Lod { get; set; }
    }
}
