using EPiServer.Core;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces
{
    /// <summary>
    /// Defines common characteristics for view models for pages, including properties used by layout files.
    /// </summary>
    /// <remarks>
    /// Views which should handle several page types (T) can use this interface as model type rather than the
    /// concrete PageViewModel class, utilizing the that this interface is covariant.
    /// </remarks>
    public interface IPageViewModel<out T>
    {
        T CurrentPage { get; }
        IContent Section { get; set; }
        ILayoutModel Layout { get; set; }
        int PageNumber { get; set; }
        string PageURL { get; set; }
        List<string> ErrorText { get; set; }
    }
}
