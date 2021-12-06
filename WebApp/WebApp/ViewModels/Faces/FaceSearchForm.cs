using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;

namespace WebApp.ViewModels.Faces
{
    public class FaceSearchForm
    {
        public int? FaceTypeId { get; set; }

        public int? BodyId { get; set; }

        public LOD? Lod { get; set; }
    }
}
