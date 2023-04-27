using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.Entities
{
    public class Customer 
    {
        [Required]
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Interview>? Interviews { get; set; }
        public virtual ICollection<RequestEntity> Requests { get; set; }
    }
}
