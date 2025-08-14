using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TB.Chatbot.Domain.Reponses
{
    public class RespReward
    {
        [JsonPropertyName("userid")]
        public string? UserId { get; set; }

        [JsonPropertyName("point")]
        public decimal? Point { get; set; }

        [JsonPropertyName("point_focus")]
        public decimal? PointFocus { get; set; }

        [JsonPropertyName("point_plus")]
        public decimal? PointPlus { get; set; }

        [JsonPropertyName("point_monthly")]
        public decimal? PointMonthly { get; set; }

        [JsonPropertyName("point_total")]
        public decimal? PointTotal { get; set; }

        [JsonPropertyName("reward_point")]
        public List<RespCmsRewardPoint>? CmsRewardPoint { get; set; }

        [JsonPropertyName("reward_promotion")]
        public List<RespCmsRewardPromotion>? CmsRewardPromotion { get; set; }
    }

    public class RespCmsRewardPoint
    {
        [JsonPropertyName("header")]
        public string? Header { get; set; }

        [JsonPropertyName("file_path_image")]
        public string? FilePathImage { get; set; }

        [JsonPropertyName("point")]
        public decimal? Point { get; set; }

        [JsonPropertyName("date_start")]
        public DateTime DateStart { get; set; }

        [JsonPropertyName("date_end")]
        public DateTime DateEnd { get; set; }
    }

    public class RespCmsRewardPromotion
    {
        [JsonPropertyName("promotion_name")]
        public string? PromotionName { get; set; }

        [JsonPropertyName("file_path_image")]
        public string? FilePathImage { get; set; }
    }
}