using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.FaceTypeOptionValues;
using WebApp.ViewModels.FaceTypes;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Faces
{
    public class FaceUpdateRequest
    {
        public int Id { get; set; }

        public int FaceTypeId { get; set; }

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public FaceTypeViewModel FaceType { get; set; }

        public List<NodeUpdateRequest> Nodes { get; set; }

        public List<FaceTypeOptionValueUpdateRequest> FaceTypeOptionValues { get; set; }
    }
}
