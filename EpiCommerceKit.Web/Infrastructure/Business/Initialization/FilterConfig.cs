﻿using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using System.Web.Mvc;
using EPiServer.ServiceLocation;

namespace EpiCommerceKit.Web.Infrastructure.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FilterConfig : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<PageContextActionFilter>());
        }

        public void Uninitialize(InitializationEngine context)
        {
            
        }
    }
}