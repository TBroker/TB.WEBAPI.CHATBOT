using Microsoft.EntityFrameworkCore;
using TB.Chatbot.Domain.Entities;

namespace TB.Chatbot.Infrastructure.DBContexts
{
    public class WebTBrokerDBContext(DbContextOptions<WebTBrokerDBContext> option) : DbContext(option)
    {
        public DbSet<WebAuthorizationOauth> WebAuthorizationOauths { get; set; }
        public DbSet<WebPremiumsMotor> WebPremiumsMotors { get; set; }
        public DbSet<WebDataMotorCoverageType> WebDataMotorCoverageTypes { get; set; }
        public DbSet<WebUserJWTAuthorized> WebUserJWTAuthorizeds { get; set; }
        public DbSet<WebCompany> WebCompanies { get; set; }
        public DbSet<WebProductCoverTxt> WebProductCoverTxts { get; set; }
        public DbSet<WebMasterPlan> WebMasterPlans { get; set; }
        public DbSet<WebUserAgent> WebUserAgents { get; set; }
        public DbSet<WebUserAgentDoc> WebUserAgentDocs { get; set; }
        public DbSet<WebUserAgentDocDetail> WebUserAgentDocDetails { get; set; }
        public DbSet<WebUserAgentDocType> WebUserAgentDocTypes { get; set; }
        public DbSet<WebCmsCommissionTaxConfig> WebCmsCommissionTaxConfigs { get; set; }
        public DbSet<WebDataCommissionRate> WebDataCommissionRates { get; set; }
        public DbSet<WebDataTracking> WebDataTrackings { get; set; }
        public DbSet<WebOrderMotor> WebOrderMotors { get; set; }
        public DbSet<WebOrderMotorPremiums> WebOrderMotorPremiums { get; set; }
        public DbSet<WebQuoRemark> WebQuoRemarks { get; set; }
        public DbSet<WebDataProductTM> WebDataProductTMs { get; set; }
        public DbSet<WebMasterPlanCondition> WebMasterPlanConditions { get; set; }
        public DbSet<WebCmsRewardPoint> WebCmsRewardPoints { get; set; }
        public DbSet<WebDataRewardPoint> WebDataRewardPoints { get; set; }
        public DbSet<WebCmsRewardPromotion> WebCmsRewardPromotions { get; set; }
    }
}