using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace EpiCommerceKit.Web.Features.Shared.Models
{   
    public abstract class SeoData : PageData
    {
        [CultureSpecific]
        [Display(
            Name = "Page Title", 
            GroupName = SystemTabNames.Content, 
            Order = 2000)]
        public virtual string SeoTitle { get; set; }

        [CultureSpecific]
        [Display(
            Name = "Page Description", 
            GroupName = SystemTabNames.Content, 
            Order = 2001)]
        [UIHint(UIHint.LongString)]
        public virtual string SeoDescription { get; set; }
    }
}