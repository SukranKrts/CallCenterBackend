using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.Entities
{
    public class Report
    {
        [Key]
        public int ReportId { get; set; }
        public int RepresentativeId { get; set; }
        public int NumberOfCustemers { get; set; }
        public DateTime TimeOfAnswer { get; set; }
        public int SolutionRate { get; set; }
    }
}
