using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Entities
{
    public class Option
    {
        public int Id { get; set; } 
        public string Name { get; set; } 
        public bool IsNumber { get; set; } 
        public List<FaceTypeOption> FaceTypeOptions { get; set; }
        public List<LineTypeOption> LineTypeOptions { get; set; }
        public List<PointTypeOption> PointTypeOptions { get; set; }
    }
}
