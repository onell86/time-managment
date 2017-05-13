using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.History;
using Microsoft.Bot.Builder.Internals.Fibers;
using TimeManagment.WebApp.Bot;
using TimeManagment.WebApp.Bot.Dialogs;
using TimeManagment.WebApp.Bot.Interfaces;
using TimeManagment.WebApp.Controllers;

namespace TimeManagment.WebApp.App_Start
{
    public static class IOConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            RegisterBotDialogs(builder);
            
            builder.RegisterType<DebugActivityLogger>().As<IActivityLogger>().InstancePerDependency();
            builder.RegisterType<AttachmentFactory>()
                .As<IAttachmentFactory>()
                .Keyed<IAttachmentFactory>(FiberModule.Key_DoNotSerialize)
                .SingleInstance();
            
            builder.Update(Conversation.Container);

            builder.RegisterType<MessagesController>().AsSelf();


            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Conversation.Container);
        }

        private static void RegisterBotDialogs(ContainerBuilder builder)
        {
            builder.RegisterType<RootDialog>().AsSelf();
            builder.RegisterType<CarouselCardsDialog>().AsSelf();
        }
    }
}