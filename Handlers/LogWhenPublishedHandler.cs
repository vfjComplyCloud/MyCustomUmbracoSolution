using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Web;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenPublishedHandler : INotificationHandler<ContentPublishedNotification>
    {
        private readonly ILogger<LogWhenPublishedHandler> _logger;
        private readonly IUmbracoContextAccessor _accessor;
        private readonly IUmbracoContext _context;

        public LogWhenPublishedHandler(ILogger<LogWhenPublishedHandler> logger, IUmbracoContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
            _accessor.TryGetUmbracoContext(out _context);
        }

        public void Handle(ContentPublishedNotification notification)
        {
            
            foreach (var publishedItem in notification.PublishedEntities)
            {
                
                int suggested = publishedItem.GetValue<int>("suggested");
                _logger.LogCritical($"Suggested: {suggested} ");


                string riskLevels = publishedItem.GetValue<string>("riskLevels");
                Guid guid = Guid.Parse(riskLevels.Replace("umb://document/", ""));
                var riskLevelNode = _context.Content.GetById(guid);
                string result = (string)riskLevelNode.GetProperty("title_en").GetValue();
                _logger.LogCritical($"Risk-Level: {result} ");


                Type industries = publishedItem.GetValue<string>("industries").GetType();
                _logger.LogCritical($"Industries: {industries} ");



                string title_en = publishedItem.GetValue<string>("title_en");
                _logger.LogCritical($"EnglishTitle: {title_en} ");

                string title_da = publishedItem.GetValue<string>("title_da");
                _logger.LogCritical($"DanishTitle: {title_da} ");



                string descriptionEN = publishedItem.GetValue<string>("descriptionEN");
                _logger.LogCritical($"EnglishDescription: {descriptionEN} ");

                string descriptionDA = publishedItem.GetValue<string>("descriptionDA");
                _logger.LogCritical($"DanishDescription: {descriptionDA} ");




                //var qq = node.GetProperty("Suggested").GetValue();

                //_logger.LogCritical($"Published date: {publishedItem.PublishDate} ");
                //_logger.LogCritical($"TEST: {publishedItem.ContentType.Name} ");
                //_logger.LogCritical(publishedItem.ContentType.IsElement.ToString());
                //_logger.LogCritical(publishedItem.ContentType.IsContainer.ToString());
                //_logger.LogCritical(publishedItem.ContentType.Key.ToString());
            }
        }
    }
}