using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.Entities
{
    public class RequestEntity
    {
        [Key]
        public int RequestId { get; set; }
        public int CustomerId { get; set; }
        public int RepresentativeId { get; set; }
        public DateTime DateOfRequest { get; set; }
        public string TypeOfRequest { get; set; }
        public int StatusOfRequest { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Representative Representative  { get; set; }
    }
}