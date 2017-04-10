using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Commerce.SpecializedProperties;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Blobs;

namespace EpiCommerceKit.Web.Features.Media
{
    [ContentType(GUID = "0282fdb6-807a-418f-a05c-84218669f986")]
    [MediaDescriptor(ExtensionString = "jpg,jpeg,jpe,ico,gif,bmp,png")]
    public class CommerceImageFile : CommerceImage
    {
        public virtual String Description { get; set; }

        [Editable(false)]
        [ImageDescriptor(Width = 128, Height = 128)]
        public override Blob LargeThumbnail { get; set; }

        [Editable(false)]
        [ImageDescriptor(Width = 64, Height = 64)]
        public override Blob Thumbnail { get; set; }
    }
}