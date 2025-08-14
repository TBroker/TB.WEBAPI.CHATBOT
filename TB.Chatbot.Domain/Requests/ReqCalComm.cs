using System.ComponentModel.DataAnnotations;

namespace TB.Chatbot.Domain.Requests
{
    public class ReqCalComm
    {
        [Required]
        public string? userid { get; set; }

        [Required]
        public string? product_code { get; set; }

        [Required]
        public string? company_code { get; set; }

        [Required]
        public string? atm_type { get; set; }

        [Required(ErrorMessage = "Total amount for VMI is required.")]
        public double? total_amount_vmi { get; set; }

        [Required(ErrorMessage = "Total amount for CMI is required.")]
        public double? total_amount_cmi { get; set; }
    }
}