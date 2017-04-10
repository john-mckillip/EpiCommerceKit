using EpiCommerceKit.Web.Infrastructure.Business.Extensions;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace EpiCommerceKit.Web.Features.Shared.Models
{
    public abstract class SitePageData : SeoData
    {
        [CultureSpecific]
        [Display(
               Name = "Page Header",
               Description = "The title of this sweet page.",
               GroupName = SystemTabNames.Content,
               Order = 1)]
        public virtual string Title
        {
            get { if (!string.IsNullOrWhiteSpace(this["Title"]?.ToString())) { return this["Title"].ToString(); } else { return Name; } }
            set { this["Title"] = value; }
        }

        [CultureSpecific]
        [Display(
            Name = "Hide Breadcrumbs",
            Description = "",
            GroupName = SystemTabNames.Content,
            Order = 2)]
        public virtual bool Breadcrumbs { get; set; }

        [Searchable]
        [Ignore]
        [Newtonsoft.Json.JsonIgnore]
        public virtual string PageTitle
        {
            get
            {
                string baseTitle = Site.SiteSettings.PageTitleSeparator + " " + Site.SiteSettings.PageTitleBase;

                if (!string.IsNullOrWhiteSpace(SeoTitle))
                {
                    if (!SeoTitle.EndsWith(baseTitle, StringComparison.InvariantCultureIgnoreCase))
                        return SeoTitle + " " + baseTitle;

                    return SeoTitle;
                }
                else
                {
                    return Name + " " + baseTitle;
                }
            }
        }
    }
}