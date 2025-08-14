using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_user_jwt_authorized")]
    public class WebUserJWTAuthorized
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string? displayname { get; set; }
        public string? username { get; set; }
        public string? password { get; set; }
        public DateTime created_date { get; set; }
        public string? status { get; set; }
    }
}