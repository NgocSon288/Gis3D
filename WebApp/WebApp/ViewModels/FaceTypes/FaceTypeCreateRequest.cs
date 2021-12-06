using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.FaceTypeOptions;

namespace WebApp.ViewModels.FaceTypes
{
    public class FaceTypeCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<FaceTypeOptionCreateRequest> FaceTypeOptions { get; set; } 
    }
}
