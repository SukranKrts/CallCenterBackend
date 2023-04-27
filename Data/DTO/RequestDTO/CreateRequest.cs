namespace CallCenterProject.Data.DTO.RequestDTO
{
    public class CreateRequest
    {
        public int CustomerId { get; set; }
        public int RepresentativeId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string TypeOfRequest { get; set; }
        public int StatusOfRequest { get; set; }
    }
}
