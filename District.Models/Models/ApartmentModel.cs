namespace District.Models.Models
{
    public class ApartmentModel
    {
        public int Id { get; set; }
        
        public int BuildingId { get; set; }
        
        public int SquareSize { get; set; }
        public int ApartmentNumber { get; set; }

        public bool IsOwn { get; set; }
    }
}
