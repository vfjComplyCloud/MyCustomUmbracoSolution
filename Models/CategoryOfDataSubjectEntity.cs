using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class CategoryOfDataSubjectEntity : PredefinedEntity
    {
        public IEnumerable<ProcessingActivityEntity> ProcessingActivities { get; set; }
        public IEnumerable<ItSystemEntity> ItSystems { get; set; }

        public CategoryOfDataSubjectEntity(CategoryOfDataSubject categoryOfDataSubject) : base(categoryOfDataSubject)
        {
            ProcessingActivities = categoryOfDataSubject.ProcessingActivities?.Select(x => new ProcessingActivityEntity((ProcessingActivity)x));
            ItSystems = categoryOfDataSubject.ITsystems?.Select(x => new ItSystemEntity((ITsystem)x));
        }
    }
}
