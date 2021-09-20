using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class PersonalDataEntity : PredefinedEntity
    {
        public IEnumerable<ProcessingActivityEntity> ProcessingActivities { get; set; }
        public IEnumerable<ItSystemEntity> ItSystems { get; set; }
        public IEnumerable<CategoryOfDataSubjectEntity> DataSubjects { get; set; }

        public PersonalDataEntity(PersonalData personalData) : base(personalData)
        {
            //                     Spelling mistake |
            //                                      V
            ProcessingActivities = personalData.ProccessingActivities?.Select(x => new ProcessingActivityEntity((ProcessingActivity)x));
            ItSystems = personalData.ITsystems?.Select(x => new ItSystemEntity((ITsystem)x));
            DataSubjects = personalData.DataSubjects?.Select(x => new CategoryOfDataSubjectEntity((CategoryOfDataSubject)x));
        }
    }
}
