using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenRestoredFromRecycleBinHandler : INotificationHandler<ContentMovingNotification>
    {
        private readonly ILogger<ContentMovingNotification> _logger;


        public LogWhenRestoredFromRecycleBinHandler(ILogger<ContentMovingNotification> logger)
        {
            _logger = logger;
        }

        public void Handle(ContentMovingNotification notification)
        {
            foreach (var item in notification.MoveInfoCollection)
                if (item.Entity.Trashed)
                    _logger.LogCritical($"RESTORED FROM THE RB: {item.Entity.Name}");
        }
    }
}