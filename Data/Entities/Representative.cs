using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.Entities
{
    public class Representative
    {
        [Required]
        [Key]
        public int RepId { get; set; }
        public string RepName { get; set; }
        public string RepMail { get; set; }
        public string RepPassword { get; set; }

        public virtual ICollection<Interview>? Interviews { get; set; }
        public virtual ICollection<RequestEntity> Requests { get; set; }

    }
}
