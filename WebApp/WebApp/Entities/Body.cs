using System.Collections.Generic;

namespace WebApp.Entities
{
    public class Body : Metadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Face> Faces { get; set; }
        public List<Line> Lines { get; set; }
        public List<Point> Points { get; set; }
    }
}