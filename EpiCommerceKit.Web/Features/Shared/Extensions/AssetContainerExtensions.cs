﻿using EPiServer;
using EPiServer.Commerce.Catalog;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EpiCommerceKit.Web.Features.Shared.Extensions
{
    public static class AssetContainerExtensions
    {
        private static Injected<AssetUrlResolver> _assetUrlResolver;

        public static string GetDefaultAsset<TContentMedia>(this IAssetContainer assetContainer)
            where TContentMedia : IContentMedia
        {
            var url = _assetUrlResolver.Service.GetAssetUrl<TContentMedia>(assetContainer);
            Uri uri;
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                return uri.PathAndQuery;
            }
            return url;
        }

        public static IList<string> GetAssets<TContentMedia>(this IAssetContainer assetContainer, IContentLoader contentLoader, UrlResolver urlResolver)
            where TContentMedia : IContentMedia
        {
            var assets = new List<string>();
            if (assetContainer.CommerceMediaCollection != null)
            {
                assets.AddRange(assetContainer.CommerceMediaCollection.Where(x => ValidateCorrectType<TContentMedia>(x.AssetLink, contentLoader)).Select(media => urlResolver.GetUrl(media.AssetLink)));
            }

            if (!assets.Any())
            {
                assets.Add(string.Empty);
            }

            return assets;
        }

        private static bool ValidateCorrectType<TContentMedia>(ContentReference contentLink, IContentLoader contentLoader)
            where TContentMedia : IContentMedia
        {
            if (typeof(TContentMedia) == typeof(IContentMedia))
            {
                return true;
            }

            if (ContentReference.IsNullOrEmpty(contentLink))
            {
                return false;
            }

            TContentMedia content;
            return contentLoader.TryGet(contentLink, out content);
        }
    }
}