using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.Entities
{
    public class Interview
    {
        [Key]
        public int InterviewId { get; set; }
        public int CustomerId { get; set; }
        public int RepresentativeId { get; set; }
        [Required]
        public string TypeOfInterview { get; set; } 
        public DateTime DateOfInterview { get; set; }
        public string Notes { get; set; }

        public virtual Representative? Representative { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}