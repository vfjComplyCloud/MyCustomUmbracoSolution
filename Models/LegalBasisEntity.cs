using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class LegalBasisEntity : BaseEntity
    {
        public IEnumerable<BaseEntity> Industries { get; set; }
        public bool RelatedToSensitiveData { get; set; }

        public LegalBasisEntity(LegalBasis legalBasis) : base(legalBasis)
        {
            Industries = legalBasis.Industries?.Select(x => new BaseEntity(x));
            RelatedToSensitiveData = legalBasis.RelatedToSensitiveData;
        }
    }
}
