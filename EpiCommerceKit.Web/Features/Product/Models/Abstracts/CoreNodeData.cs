using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace EpiCommerceKit.Web.Features.Product.Models.Abstracts
{
    public abstract class CoreNodeData : NodeContent
    {
        [Tokenize]
        [Searchable]
        [CultureSpecific]
        [Display(
            Name = "Description",
            GroupName = SystemTabNames.Content,
            Order = 20)]
        public virtual XhtmlString CategoryDescription { get; set; }


        public override string DisplayName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(base.DisplayName))
                    return base.Name;

                return base.DisplayName;
            }
            set
            {
                base.DisplayName = value;
            }
        }
    }
}