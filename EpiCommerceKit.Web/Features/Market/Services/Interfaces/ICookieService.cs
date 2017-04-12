using System.Web;

namespace EpiCommerceKit.Web.Features.Market.Services.Interfaces
{
    public interface ICookieService
    {
        string Get(string cookie);
        void Set(string cookie, string value);
        void Remove(string cookie);
    }
}

