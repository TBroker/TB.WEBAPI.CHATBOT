using System.ComponentModel;

namespace TB.Chatbot.Domain.Enums
{
    public enum ContentMessage
    {
        [Description("Found Information")]
        Found,

        [Description("NotFound Information")]
        NotFound,

        [Description("OK")]
        Ok,

        [Description("No Content")]
        NoContent,

        [Description("Internal Server Error")]
        InternalServerError,

        [Description("Bad Request")]
        BadRequest,

        [Description("Cannot request more than 4 Items.")]
        NoMoreThan4Item,

        [Description("Quote added successfully")]
        QuoteSuccess,

        [Description("Failed to add quote due to incomplete data")]
        QuoteFailure,
    }
}