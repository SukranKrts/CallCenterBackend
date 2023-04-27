namespace CallCenterProject.Data.DTO.InterviewDTO
{
    public class InterviewCreate
    {
        public int CustomerId { get; set; }
        public int RepresentativeId { get; set; }
        public string TypeOfInterview { get; set; }
        public DateTime DateOfInterview { get; set; }
        public int Notes { get; set; }
    }
}
