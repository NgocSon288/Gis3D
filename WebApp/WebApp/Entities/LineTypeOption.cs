namespace WebApp.Entities
{
    public class LineTypeOption
    {
        public int Id { get; set; } 
        public int LineTypeId { get; set; } 
        public int OptionId { get; set; } 
        public LineType LineType { get; set; } 
        public Option Option { get; set; }
    }
}