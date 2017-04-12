using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiCommerceKit.Web.Features.Product.Models.Abstracts
{
    public abstract class CoreBundleData : BundleContent
    {
        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [Display(Name = "Description", Order = 1)]
        public virtual XhtmlString Description { get; set; }
    }
}