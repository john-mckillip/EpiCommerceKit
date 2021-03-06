﻿using EPiServer.Commerce.Catalog.DataAnnotations;
using EpiCommerceKit.Web.Features.Product.Models.Abstracts;

namespace EpiCommerceKit.Web.Features.Product.Models
{
    [CatalogContentType(
        DisplayName = "Product Category", 
        GUID = "3412aa79-7706-40f6-90aa-380885182108",
        MetaClassName = "ProductCategoryData")]
    public class ProductCategoryData : CoreNodeData { }
}