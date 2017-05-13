using System.Collections.Generic;
using Microsoft.Bot.Connector;
using TimeManagment.WebApp.Bot.Interfaces;

namespace TimeManagment.WebApp.Bot
{
    public class AttachmentFactory : IAttachmentFactory
    {
        public Attachment CreateHeroCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var heroCard = new HeroCard
            {
                Title = title,
                Subtitle = subtitle,
                Text = text,
                Images = new List<CardImage> { cardImage },
                Buttons = new List<CardAction> { cardAction }
            };

            return heroCard.ToAttachment();
        }

        public Attachment GetThumbnailCard(string title, string subtitle, string text, CardImage cardImage, CardAction cardAction)
        {
            var thumbnailCard = new ThumbnailCard
            {
                Title = title,
                Subtitle =  subtitle,
                Text = text,
                Images = new List<CardImage> { cardImage},
                Buttons = new List<CardAction> { cardAction }
            };

            return thumbnailCard.ToAttachment();
        }



    }
}