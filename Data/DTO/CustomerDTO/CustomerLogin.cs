using System.ComponentModel.DataAnnotations;

namespace CallCenterProject.Data.DTO.CustomerDTO
{
    public class CustomerLogin
    {
        public string CustomerName { get; set; }
        public string CustomerMail { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerPassword { get; set; }
    }
}
