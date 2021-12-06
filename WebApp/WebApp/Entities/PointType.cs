using System.Collections.Generic;

namespace WebApp.Entities
{
    public class PointType : Metadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<PointTypeOption> PointTypeOptions { get; set; }
        public List<Point> Points { get; set; }
    }
}