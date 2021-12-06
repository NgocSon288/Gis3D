namespace WebApp.Entities
{
    public class LineTypeOptionValue
    {
        public int Id { get; set; }
        public int LineTypeOptionId { get; set; }
        public int LineId { get; set; }
        public double ValueN { get; set; }
        public string ValueS { get; set; }
        public Line Line { get; set; }
    }
}