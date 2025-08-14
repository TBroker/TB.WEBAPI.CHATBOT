using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TB.Chatbot.Domain.Entities
{
    [Table("web_user_agent")]
    public class WebUserAgent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal id { get; set; }

        public DateTime date_create { get; set; }
        public DateTime date_update { get; set; }
        public string? create_by { get; set; }
        public string? AgentType { get; set; }
        public string? UserID { get; set; }
        public string? Password { get; set; }
        public string? TitleCode { get; set; }
        public string? TitleTxt { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? IdCard { get; set; }
        public string? MobilePhone { get; set; }
        public string? Email { get; set; }
        public string? OTPTo { get; set; }
        public string? GroupAgent { get; set; }
        public string? BusinessType { get; set; }
        public string? ProfitSharingCode { get; set; }
        public string? GeneralBusinessType { get; set; }
        public string? GeneralBusinessTypeTxt { get; set; }
        public string? GeneralBusinessTypeOtherTxt { get; set; }
        public string? GarageName { get; set; }
        public string? GaragePhone { get; set; }
        public string? GarageProvince { get; set; }
        public string? GarageProvinceTxt { get; set; }
        public string? BUInfo { get; set; }
        public string? BUInfoTxt { get; set; }
        public string? RefAgentCode { get; set; }
        public string? RefAgentName { get; set; }
        public string? NewsletterAccept { get; set; }
        public string? ImgProfile { get; set; }
        public string? TitleCode_en { get; set; }
        public string? TitleTxt_en { get; set; }
        public string? Name_en { get; set; }
        public string? LastName_en { get; set; }
        public string? Birthdate { get; set; }
        public string? Gender { get; set; }
        public string? Nationality { get; set; }
        public string? EducationLevel { get; set; }
        public string? EducationLevelTxt { get; set; }
        public string? Academy { get; set; }
        public string? Salary { get; set; }
        public string? MaritalStatus { get; set; }
        public string? AddressName { get; set; }
        public string? AddressRoom { get; set; }
        public string? AddressNo { get; set; }
        public string? AddressAlley { get; set; }
        public string? AddressStreet { get; set; }
        public string? AddressProvince { get; set; }
        public string? AddressProvinceTxt { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressDistrictTxt { get; set; }
        public string? AddressSubDistrict { get; set; }
        public string? AddressSubDistrictTxt { get; set; }
        public string? AddressZipcode { get; set; }
        public string? BankAccount { get; set; }
        public string? BankAccountTxt { get; set; }
        public string? BankBranch { get; set; }
        public string? BankAccountName { get; set; }
        public string? BankAccountNo { get; set; }
        public string? CareerCode { get; set; }
        public string? CareerTxt { get; set; }
        public string? CareerOtherTxt { get; set; }
        public string? LineID { get; set; }
        public string? Facebook { get; set; }
        public string? ShareQRCode { get; set; }
        public string? ShareQRCodePosition { get; set; }
        public string? ShareQRCodeTextInfo { get; set; }
        public string? ShareQRCodePosition_EN { get; set; }
        public string? ShareQRCodeTextInfo_EN { get; set; }
        public string? MLMAgentCode { get; set; }
        public string? MLMAgentName { get; set; }
        public string? PasswordFromImport { get; set; }
        public string? GarageOfficePhone { get; set; }
        public string? IdCardSHA256 { get; set; }
        public string? LEVEL_X { get; set; }
        public string? ACCOUNT_TYPE { get; set; }
        public decimal Credit_limit { get; set; }
        public string? TopAgentCode { get; set; }
        public decimal CREDIT_USED { get; set; }
        public DateTime CREDIT_USED_UPDATE { get; set; }
        public string? ACTIVE { get; set; }
        public string? FamilyType { get; set; }
        public string? BRANCH_AFFILIATED_CODE { get; set; }
        public string? PROVINCE_AFFILIATED_CODE { get; set; }
        public string? license { get; set; }
        public string? DATE_OF_NO { get; set; }
        public string? DATE_OF_ISSUE { get; set; }
        public string? DATE_OF_EXPIRY { get; set; }
        public string? license2 { get; set; }
        public string? DATE2_OF_NO { get; set; }
        public string? DATE2_OF_ISSUE { get; set; }
        public string? DATE2_OF_EXPIRY { get; set; }
    }
}