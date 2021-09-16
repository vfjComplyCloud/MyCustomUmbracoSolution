using Microsoft.Extensions.Logging;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenUnpublishedHandler : INotificationHandler<ContentUnpublishedNotification>
    {
        private readonly ILogger<LogWhenUnpublishedHandler> _logger;

        public LogWhenUnpublishedHandler(ILogger<LogWhenUnpublishedHandler> logger)
        {
            _logger = logger;
        }

        public void Handle(ContentUnpublishedNotification notification)
        {
            foreach (var unpublishedItem in notification.UnpublishedEntities)
            {
                _logger.LogCritical($"Name: {unpublishedItem.Name} ");
                if (!unpublishedItem.Published) _logger.LogCritical($"UnpublishedDate: {unpublishedItem.UpdateDate} ");
                _logger.LogCritical($"ContentType.Name: {unpublishedItem.ContentType.Name} ");
                _logger.LogCritical(unpublishedItem.ContentType.IsElement.ToString());
                _logger.LogCritical(unpublishedItem.ContentType.IsContainer.ToString());
                _logger.LogCritical(unpublishedItem.ContentType.Key.ToString());
            }
        }
    }
}