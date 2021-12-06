using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Enums;
using WebApp.ViewModels.FaceTypeOptionValues;
using WebApp.ViewModels.Nodes;

namespace WebApp.ViewModels.Faces
{
    public class FaceCreateRequest
    {
        public int FaceTypeId { get; set; }     // Chọn FaceType, sẽ render form tương ứng, truyền xuống server để biết lưu

        public int? BodyId { get; set; }            // Chọn body

        public LOD Lod { get; set; }                // Chọn độ chi tiết

        public string Description { get; set; }     // Mô tả metadata

        public List<NodeCreateRequest> Nodes { get; set; }

        public List<FaceTypeOptionValueCreateRequest> FaceTypeOptionValues { get; set; }
    }
}
