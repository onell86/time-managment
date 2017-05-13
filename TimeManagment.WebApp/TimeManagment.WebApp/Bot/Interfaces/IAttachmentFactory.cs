using Microsoft.Bot.Connector;

namespace TimeManagment.WebApp.Bot.Interfaces
{
    public interface IAttachmentFactory
    {
        Attachment CreateHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction);
        Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction);
    }
}
