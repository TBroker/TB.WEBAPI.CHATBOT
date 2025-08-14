using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_data_motor_coverage_type")]
    public class WebDataMotorCoverageType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? coverage_code { get; set; }
        public string? coverage_name { get; set; }
    }
}