using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace MyCustomUmbracoSolution.Models
{
    public class BaseEntity
    {
        public string Title { get; set; }
        public Guid Id { get; set; }
        public int MetaId { get; set; }


        public BaseEntity(IPublishedContent content)
        {
            Title = content.Name;
            Id = content.Key;
            MetaId = content.Id;
        }
    }
}
