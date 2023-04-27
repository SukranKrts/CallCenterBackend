namespace CallCenterProject.Data.DTO.RequestDTO
{
    public class RequestInfo
    {
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public int RepresentativeId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string TypeOfRequest { get; set; }
        public int StatusOfRequest { get; set; }
    }
}
