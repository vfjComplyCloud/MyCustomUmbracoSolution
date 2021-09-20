using System;
using Microsoft.Extensions.Logging;
using MyCustomUmbracoSolution.Models;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services.Implement;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Handlers
{
    public class LogWhenMovedToRecycleBinHandler : INotificationHandler<ContentMovedToRecycleBinNotification>
    {
        private readonly ILogger<LogWhenMovedToRecycleBinHandler> _logger;
        private readonly IUmbracoContextAccessor _accessor;
        private readonly IUmbracoContext _context;

        public LogWhenMovedToRecycleBinHandler(ILogger<LogWhenMovedToRecycleBinHandler> logger, IUmbracoContextAccessor accessor)
        {
            _logger = logger;
            _accessor = accessor;
            _accessor.TryGetUmbracoContext(out _context);
        }
        public void Handle(ContentMovedToRecycleBinNotification notification)
        {
            foreach (MoveEventInfo<IContent> moveInfo in notification.MoveInfoCollection)
            {
                IContent movedItem = moveInfo.Entity;

                IPublishedContent content = _context.Content.GetById(movedItem.Id);

                switch (content)
                {
                    case ProcessingActivity processingActivity:
                        ProcessingActivityEntity processingActivityEntity = new(processingActivity);
                        break;
                    case PurposeOfProcessing purposeOfProcessing:
                        PurposeOfProcessingEntity purposeOfProcessingEntity = new(purposeOfProcessing);
                        break;
                    case ITsystem itSystem:
                        ItSystemEntity itSystemEntity = new(itSystem);
                        break;
                    case ErasurePolicy erasurePolicy:
                        ErasurePolicyEntity erasurePolicyEntity = new(erasurePolicy);
                        break;
                    case PersonalData personalData:
                        PersonalDataEntity personalDataEntity = new(personalData);
                        break;
                    case LegalBasis legalBasis:
                        LegalBasisEntity legalBasisEntity = new(legalBasis);
                        break;
                    case RecipientCategory recipientCategory:
                        RecipientCategoryEntity recipientCategoryEntity = new(recipientCategory);
                        break;
                    case CategoryOfDataSubject categoryOfDataSubject:
                        CategoryOfDataSubjectEntity categoryOfDataSubjectEntity = new(categoryOfDataSubject);
                        break;

                    case ITest predefined:
                        //PredefinedEntity predefinedEntity = new(predefined);
                        break;
                    default:
                        //BaseEntity baseEntity = new(content);
                        break;
                }
            }
        }
    }
}