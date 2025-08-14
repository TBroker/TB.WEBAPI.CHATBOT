using System.ComponentModel;
using TB.Chatbot.Application.Interfaces;
using TB.Chatbot.Domain.Enums;

namespace TB.Chatbot.Application.Services
{
    public class HelperService : IHelperService
    {
        public async Task<string> GetDescription(Enum value)
        {
            try
            {
                var field = value.GetType().GetField(value.ToString());
                var attribute = (DescriptionAttribute)Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute))!;
                return await Task.Run(() => attribute == null ? value.ToString() : attribute.Description);
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }

        public async Task<string> GetBusinessType(string businessType)
        {
            try
            {
                Enum.TryParse<BusinessType>(businessType, out var value);
                return await Task.Run(() => value.ToString());
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(ex.Message);
            }
        }
    }
}