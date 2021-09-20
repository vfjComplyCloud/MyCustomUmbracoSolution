using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class PredefinedEntity : BaseEntity
    {
        public bool Suggested { get; set; }
        public BaseEntity RiskLevel { get; set; }

        public PredefinedEntity(ITest predifined) : base(predifined)
        {
            Suggested = predifined.Suggested;
            RiskLevel = new BaseEntity(predifined.RiskLevels);
        }
    }
}
