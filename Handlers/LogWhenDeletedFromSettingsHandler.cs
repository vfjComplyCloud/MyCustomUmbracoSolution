using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace MyCustomUmbracoSolution.Handlers
{
    // Only handles notifications from deletes from the "Settings"-page - not the "Content"-page!
    public class LogWhenDeletedFromSettingsHandler : INotificationHandler<ContentDeletedNotification>
    {
        private readonly ILogger<LogWhenDeletedFromSettingsHandler> _logger;

        public LogWhenDeletedFromSettingsHandler(ILogger<LogWhenDeletedFromSettingsHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(ContentDeletedNotification notification)
        {
            foreach (var deletedItem in notification.DeletedEntities)
                _logger.LogInformation($"{deletedItem.Name} was deleted from SETTINGS-tab");
        }
    }
}