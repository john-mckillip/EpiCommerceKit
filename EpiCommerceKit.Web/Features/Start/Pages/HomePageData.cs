using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EpiCommerceKit.Web.Features.Shared.Models;
using EpiCommerceKit.Web.Models.Features.Start.Blocks;

namespace EpiCommerceKit.Web.Features.Start.Pages
{
    [ContentType(
        DisplayName = "Home Page", 
        GUID = "a9d6dd50-8983-49de-974a-5748792ff1b8", 
        Description = "")]
    public class HomePageData : SitePageData
    {
        #region Global Settings

        [Display(
            Name = "Global Site Settings",
            GroupName = SystemTabNames.Settings,
            Order = 52)]
        public virtual SiteSettingsData SiteSettings { get; set; }

        #endregion
    }
}