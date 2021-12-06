namespace WebApp.Entities
{
    public class FaceTypeOption
    {
        public int Id { get; set; }
        public int FaceTypeId { get; set; }
        public int OptionId { get; set; }
        public FaceType FaceType { get; set; }
        public Option Option { get; set; }
    }
}