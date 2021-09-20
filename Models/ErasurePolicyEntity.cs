using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class ErasurePolicyEntity : PredefinedEntity
    {
        public IEnumerable<ProcessingActivityEntity> ProcessingActivities { get; set; }
        public IEnumerable<ItSystemEntity> ItSystems { get; set; }
        public IEnumerable<CategoryOfDataSubjectEntity> DataSubjects { get; set; }

        public ErasurePolicyEntity(ErasurePolicy purposeOfProcessing) : base(purposeOfProcessing)
        {
            ProcessingActivities = purposeOfProcessing.ProcessingActivities?.Select(x => new ProcessingActivityEntity((ProcessingActivity)x));
            ItSystems = purposeOfProcessing.ITsystems?.Select(x => new ItSystemEntity((ITsystem)x));
            DataSubjects = purposeOfProcessing.DataSubjects?.Select(x => new CategoryOfDataSubjectEntity((CategoryOfDataSubject)x));
        }
    }
}
