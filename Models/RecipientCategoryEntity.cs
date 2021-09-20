using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class RecipientCategoryEntity : PredefinedEntity
    {
        public IEnumerable<ProcessingActivityEntity> ProcessingActivities { get; set; }
        public IEnumerable<ItSystemEntity> ItSystems { get; set; }

        public RecipientCategoryEntity(RecipientCategory recipientCategory) : base(recipientCategory)
        {
            ProcessingActivities = recipientCategory.ProcessingActivities?.Select(x => new ProcessingActivityEntity((ProcessingActivity)x));
            ItSystems = recipientCategory.ITsystems?.Select(x => new ItSystemEntity((ITsystem)x));
        }
    }
}
