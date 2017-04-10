using Mediachase.Commerce;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Shared.Services.Interfaces
{
    public interface ICurrencyService
    {
        IEnumerable<Currency> GetAvailableCurrencies();
        Currency GetCurrentCurrency();
        bool SetCurrentCurrency(string currencyCode);
    }
}
