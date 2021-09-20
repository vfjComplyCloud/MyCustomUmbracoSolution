﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoSolution.Models
{
    public class ProcessingActivityEntity : PredefinedEntity
    {
        public IEnumerable<BaseEntity> Industries { get; set; }

        public ProcessingActivityEntity(ProcessingActivity processingActivity) : base(processingActivity)
        {
            Industries = processingActivity.Industries?.Select(x => new BaseEntity(x));
        }
    }
}
