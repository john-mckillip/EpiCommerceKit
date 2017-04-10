using EPiServer.Commerce.Catalog.ContentTypes;
using Mediachase.Commerce;
using Mediachase.Commerce.Catalog;
using Mediachase.Commerce.Pricing;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Shared.Services.Interfaces
{
    public interface IPromotionService
    {
        IList<IPriceValue> GetDiscountPriceList(IEnumerable<CatalogKey> catalogKeys, MarketId marketId, Currency currency);
        IPriceValue GetDiscountPrice(CatalogKey catalogKey, MarketId marketId, Currency currency);
        IPriceValue GetDiscountPrice(IPriceValue price, EntryContentBase entry, Currency currency, IMarket market);
    }
}
