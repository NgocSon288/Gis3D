using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.ViewModels.LineTypeOptions;

namespace WebApp.ViewModels.LineTypes
{
    public class LineTypeCreateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<LineTypeOptionCreateRequest> LineTypeOptions { get; set; }
    }
}
