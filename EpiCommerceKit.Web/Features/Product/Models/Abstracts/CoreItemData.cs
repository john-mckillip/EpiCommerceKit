using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Commerce.Catalog.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAnnotations;
using Mediachase.Commerce.Catalog.Managers;
using Mediachase.Commerce.Catalog.Objects;
using Mediachase.Commerce.Pricing;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EpiCommerceKit.Web.Features.Product.Models.Abstracts
{
    public abstract class CoreItemData : VariationContent
    {
        private Price _ListPrice;

        [Searchable]
        [Tokenize]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyString))]
        [Display(Name = "Size", Order = 1)]
        public virtual string Size { get; set; }

        [Searchable]
        [CultureSpecific]
        [Tokenize]
        [IncludeInDefaultSearch]
        [BackingType(typeof(PropertyString))]
        [Display(Name = "Color", Order = 2)]
        public virtual string Color { get; set; }

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