using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;

namespace WebApp.ViewModels.Lines
{
    public class LineSearchForm
    {
        public int? LineTypeId { get; set; }

        public int? BodyId { get; set; }

        public LOD? Lod { get; set; }
    }
}
