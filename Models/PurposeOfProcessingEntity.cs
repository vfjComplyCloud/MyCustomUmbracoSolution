using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class PurposeOfProcessingEntity : PredefinedEntity
    {
        public IEnumerable<BaseEntity> Industries { get; set; }
        public IEnumerable<ProcessingActivityEntity> ProcessingActivities { get; set; }
        public IEnumerable<ItSystemEntity> ItSystems { get; set; }

        public PurposeOfProcessingEntity(PurposeOfProcessing purposeOfProcessing) : base(purposeOfProcessing)
        {
            Industries = purposeOfProcessing.Industries?.Select(x => new BaseEntity(x));
            ProcessingActivities = purposeOfProcessing.ProcessingActivities?.Select(x => new ProcessingActivityEntity((ProcessingActivity)x));
            ItSystems = purposeOfProcessing.ITsystems?.Select(x => new ItSystemEntity((ITsystem)x));
        }
    }
}
