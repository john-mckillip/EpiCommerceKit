using EPiServer.Core;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Product.ViewModels.Abstracts
{
    public abstract class ProductViewModelBase
    {
        public IList<string> Images { get; set; }
        public IEnumerable<ContentReference> AlternativeProducts { get; set; }
        public IEnumerable<ContentReference> CrossSellProducts { get; set; }
    }
}