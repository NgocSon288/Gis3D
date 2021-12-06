namespace WebApp.Entities
{
    public class PointTypeOption
    {
        public int Id { get; set; }
        public int PointTypeId { get; set; }
        public int OptionId { get; set; }
        public PointType PointType { get; set; }
        public Option Option { get; set; }
    }
}