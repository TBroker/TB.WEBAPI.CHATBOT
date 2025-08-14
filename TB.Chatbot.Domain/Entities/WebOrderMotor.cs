using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_order_motor")]
    public class WebOrderMotor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? status_system { get; set; }
        public string? status_payment { get; set; }
        public string? UserID { get; set; }
        public string? quo_number { get; set; }
        public string? tm_product_code { get; set; }
        public string? coverage_code { get; set; }
        public string? car_brand { get; set; }
        public string? car_model { get; set; }
        public string? car_sub_model { get; set; }
        public string? car_engine_size { get; set; }
        public string? car_year { get; set; }
        public string? name { get; set; }
        public string? last_name { get; set; }
        public string? vehicle_license { get; set; }
        public string? phone_number { get; set; }
        public string? email { get; set; }
        public string? buy_cmi { get; set; }
        public string? is_cmi { get; set; }
        public int status { get; set; }
        public string? quo_remark { get; set; }
        public string? en_quo_remark { get; set; }
    }
}