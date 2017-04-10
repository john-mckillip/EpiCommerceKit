using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace EpiCommerceKit.Web.Features.Media
{
    [ContentType(DisplayName = "Generic Media", GUID = "73c503c7-70ae-4b3c-98b3-1e921841f0ad", Description = "")]
    public class GenericMediaData : MediaData
    {
        [CultureSpecific]
        [Editable(true)]
        [Display(
             Name = "Description",
             Description = "Details about the file",
             GroupName = SystemTabNames.Content,
             Order = 1)]
        public virtual string Description { get; set; }
    }
}