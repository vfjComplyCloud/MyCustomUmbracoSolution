using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class ItSystemEntity : PredefinedEntity
    {
        public IEnumerable<BaseEntity> Industries { get; set; }

        public ItSystemEntity(ITsystem itSystem) : base(itSystem)
        {
            Industries = itSystem.Industries?.Select(x => new BaseEntity(x));
        }
    }
}
