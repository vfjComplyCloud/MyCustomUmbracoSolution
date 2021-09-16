using System;
using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services.Implement;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenMovedToRecycleBinHandler : INotificationHandler<ContentMovedToRecycleBinNotification>
    {
        private readonly ILogger<LogWhenMovedToRecycleBinHandler> _logger;

        public LogWhenMovedToRecycleBinHandler(ILogger<LogWhenMovedToRecycleBinHandler> logger)
        {
            _logger = logger;
        }
        public void Handle(ContentMovedToRecycleBinNotification notification)
        {
            foreach (var trashedItem in notification.MoveInfoCollection)
            {
                _logger.LogInformation($"{trashedItem.Entity.Name} was deleted from CONTENT-tab");
                _logger.LogInformation($"IS TRASHED: {trashedItem.Entity.Trashed} ");
            }
        }
    }
}