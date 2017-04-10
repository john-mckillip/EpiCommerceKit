using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;
using Mediachase.Commerce.Catalog.Managers;
using Mediachase.Commerce.Catalog.Objects;
using Mediachase.Commerce.Pricing;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EpiCommerceKit.Web.Features.Product.Abstracts
{
    public abstract class CoreItemData : VariationContent
    {
        private Price _ListPrice;
        
        [Editable(false)]
        [Display(
           Name = "Manufacturer",
           GroupName = SystemTabNames.Content,
           Order = 21)]
        public virtual string Manufacturer { get; set; }
        
        [CultureSpecific]
        [Display(
            Name = "Small Image",
            GroupName = SystemTabNames.Content,
            Order = 31)]
        public virtual string ImageSmall { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Large Image",
            GroupName = SystemTabNames.Content,
            Order = 32)]
        public virtual string ImageBig { get; set; }

        [Tokenize]
        [Searchable]
        [CultureSpecific]
        [Display(
            Name = "Teaser",
            GroupName = SystemTabNames.Content,
            Order = 40)]
        [UIHint(UIHint.Textarea)]
        public virtual string Teaser { get; set; }

        [Tokenize]
        [Searchable]
        [CultureSpecific]
        [Display(
            Name = "Description",
            GroupName = SystemTabNames.Content,
            Order = 50)]
        public virtual XhtmlString Description { get; set; }
        
        [Ignore]
        public virtual Price ListPrice
        {
            get
            {
                if (_ListPrice == null)
                {
                    var entry = this.LoadEntry(CatalogEntryResponseGroup.ResponseGroup.Variations);

                    if (entry == null)
                        return null;

                    var price = entry.PriceValues.PriceValue
                        .OrderByDescending<PriceValue, decimal>((PriceValue p) => p.UnitPrice.Amount).FirstOrDefault<PriceValue>();

                    if (price == null)
                        return null;

                    _ListPrice = new Price(price.UnitPrice);
                }

                return _ListPrice;
            }
        }
    }
}