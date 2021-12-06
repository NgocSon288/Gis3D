using System.Collections.Generic;

namespace WebApp.Entities
{
    public class LineType : Metadata
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LineTypeOption> LineTypeOptions { get; set; }
        public List<Line> Lines { get; set; }
    }
}