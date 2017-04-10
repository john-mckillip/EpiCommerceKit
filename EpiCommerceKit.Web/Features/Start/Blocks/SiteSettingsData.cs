using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Commerce.Catalog.ContentTypes;
using EPiServer.Web;

namespace EpiCommerceKit.Web.Models.Features.Start.Blocks
{
    [ContentType(
        DisplayName = "Site Settings", 
        GUID = "b6a25cbd-739f-49f6-96f8-1faecf937271", 
        Description = "")]
    public class SiteSettingsData : BlockData
    {
        [CultureSpecific]
        [Display(
            Name = "Root Catalog Reference",
            Description = "",
           GroupName = SystemTabNames.Settings,
            Order = 0)]
        [AllowedTypes(typeof(CatalogContent))]
        [UIHint(EPiServer.Commerce.UIHint.CatalogContent)]
        public virtual ContentReference CatalogRoot
        {
            get { if (this["CatalogRoot"] != null) { return this["CatalogRoot"] as ContentReference; } else { return ContentReference.StartPage; } }
            set { this["CatalogRoot"] = value; }
        }

        [Display(Name = "Page Title Base", GroupName = SystemTabNames.Settings, Order = 1)]
        public virtual string PageTitleBase { get; set; }

        [Display(Name = "Page Title Separator", GroupName = SystemTabNames.Settings, Order = 2)]
        public virtual string PageTitleSeparator { get; set; }

        [Display(Name = "Logo", GroupName = SystemTabNames.Settings, Order = 3)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Logo
        {
            get { if (this["Logo"] != null) { return this["Logo"] as ContentReference; } else { return ContentReference.StartPage; } }
            set { this["Logo"] = value; }
        }

        [Display(Name = "Logo Text", GroupName = SystemTabNames.Settings, Order = 4)]
        public virtual string LogoText
        {
            get { if (this["LogoText"] != null) { return this["LogoText"] as string; } else { return "Shoup Manufacturing"; } }
            set { this["LogoText"] = value; }
        }
    }
}