//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Category of data subject</summary>
	[PublishedModel("categoryOfDataSubject")]
	public partial class CategoryOfDataSubject : PublishedContentModel, IDescription, ITest, ITitleSet
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		public new const string ModelTypeAlias = "categoryOfDataSubject";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<CategoryOfDataSubject, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public CategoryOfDataSubject(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// IT-Systems
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("iTSystems")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent> ITsystems => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>>(_publishedValueFallback, "iTSystems");

		///<summary>
		/// Processing Activities
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("processingActivities")]
		public virtual global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent> ProcessingActivities => this.Value<global::System.Collections.Generic.IEnumerable<global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent>>(_publishedValueFallback, "processingActivities");

		///<summary>
		/// Danish
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("descriptionDA")]
		public virtual string DescriptionDA => global::Umbraco.Cms.Web.Common.PublishedModels.Description.GetDescriptionDA(this, _publishedValueFallback);

		///<summary>
		/// English
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("descriptionEN")]
		public virtual string DescriptionEN => global::Umbraco.Cms.Web.Common.PublishedModels.Description.GetDescriptionEN(this, _publishedValueFallback);

		///<summary>
		/// Risk-levels
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("riskLevels")]
		public virtual global::Umbraco.Cms.Core.Models.PublishedContent.IPublishedContent RiskLevels => global::Umbraco.Cms.Web.Common.PublishedModels.Test.GetRiskLevels(this, _publishedValueFallback);

		///<summary>
		/// Suggested
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("suggested")]
		public virtual bool Suggested => global::Umbraco.Cms.Web.Common.PublishedModels.Test.GetSuggested(this, _publishedValueFallback);

		///<summary>
		/// Danish
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("title_da")]
		public virtual string Title_da => global::Umbraco.Cms.Web.Common.PublishedModels.TitleSet.GetTitle_da(this, _publishedValueFallback);

		///<summary>
		/// English
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "9.0.0-rc003+36582f2cd2c6ddc797c85dac0a9a6572126bf602")]
		[ImplementPropertyType("title_en")]
		public virtual string Title_en => global::Umbraco.Cms.Web.Common.PublishedModels.TitleSet.GetTitle_en(this, _publishedValueFallback);
	}
}
