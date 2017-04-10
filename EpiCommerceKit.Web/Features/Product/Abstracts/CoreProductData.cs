using EPiServer.Commerce.Catalog.ContentTypes;

namespace EpiCommerceKit.Web.Features.Product.Abstracts
{
    public class CoreProductData : ProductContent
    {

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