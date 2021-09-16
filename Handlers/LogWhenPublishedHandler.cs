using Microsoft.Extensions.Logging;
using MyCustomUmbracoLibrary;
using MyCustomUmbracoLibrary.MetaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models.PublishedContent;
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
                IPublishedContent content = _context.Content.GetById(publishedItem.Id);

                Type model = ModelRegister.MetaModels[content.ContentType.Alias];

                object item = Activator.CreateInstance(model);

                foreach(PropertyInfo property in model.GetProperties())
                {
                    string alias = (string)model.GetNestedType("Fields").GetField(property.Name).GetValue(null);
                    property.SetValue(item, content.GetProperty(alias).GetValue());
                }

                //Umbraco.Cms.Web.Common.PublishedModels.ITsystem test = new();

                var test = content.GetProperty(MetaITSystem.Fields.Suggested);
                var test2 = test.GetType();
                var test3 = test.GetValue();

                var testA = content.GetProperty(MetaITSystem.Fields.RiskLevel);
                var testA2 = testA.GetType();
                IPublishedContent testA3 = (IPublishedContent)testA.GetValue();

                //var testAB = content.GetProperty("industries");
                //var testAB2 = testAB.GetType();
                //var testAB3 = testAB.GetValue();




                //var riskLevelObj = publishedItem.GetValue<object>("riskLevels");
                //var props = publishedItem.Properties;

                //var testing = _context.Content.GetById(1163);

                //var industryIds = new List<Guid>();
                //string[] industryList = publishedItem.GetValue<string>("industries").Split(',');
                //foreach (var item in industryList)
                //{
                //    Guid industryId = Guid.Parse(item.Replace("umb://document/", ""));
                //    industryIds.Add(industryId);
                //}

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