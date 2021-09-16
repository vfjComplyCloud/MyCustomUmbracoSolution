using Microsoft.Extensions.Logging;
using System;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenUnpublishedHandler : INotificationHandler<ContentUnpublishedNotification>
    {
        private readonly ILogger<LogWhenUnpublishedHandler> _logger;
        private readonly IUmbracoContextAccessor _accessor;
        private readonly IUmbracoContext _context;

        public LogWhenUnpublishedHandler(ILogger<LogWhenUnpublishedHandler> logger, IUmbracoContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
            _accessor.TryGetUmbracoContext(out _context);
        }

        public void Handle(ContentUnpublishedNotification notification)
        {            
            foreach (var unpublishedItem in notification.UnpublishedEntities)
            {
                int suggested = unpublishedItem.GetValue<int>("suggested");
                _logger.LogCritical($"Suggested: {suggested} ");


                string riskLevels = unpublishedItem.GetValue<string>("riskLevels");
                Guid guid = Guid.Parse(riskLevels.Replace("umb://document/", ""));
                var riskLevelNode = _context.Content.GetById(guid);
                string result = (string)riskLevelNode.GetProperty("title_en").GetValue();
                _logger.LogCritical($"Risk-Level: {result} ");

                string industries = unpublishedItem.GetValue<string>("industries");
                Guid guid2 = Guid.Parse(industries.Replace("umb://document/", ""));
                var industryNode = _context.Content.GetById(guid2);
                string result2 = (string)industryNode.GetProperty("title_en").GetValue();
                _logger.LogCritical($"Industries: {result2} ");



                string title_en = unpublishedItem.GetValue<string>("title_en");
                _logger.LogCritical($"EnglishTitle: {title_en} ");

                string title_da = unpublishedItem.GetValue<string>("title_da");
                _logger.LogCritical($"DanishTitle: {title_da} ");



                string descriptionEN = unpublishedItem.GetValue<string>("descriptionEN");
                _logger.LogCritical($"EnglishDescription: {descriptionEN} ");

                string descriptionDA = unpublishedItem.GetValue<string>("descriptionDA");
                _logger.LogCritical($"DanishDescription: {descriptionDA} ");
            }
        }
    }
}