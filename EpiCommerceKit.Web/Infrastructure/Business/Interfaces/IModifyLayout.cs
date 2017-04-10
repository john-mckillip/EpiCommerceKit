using EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces;

namespace EpiCommerceKit.Web.Infrastructure.Business.Interfaces
{
    /// <summary>
    /// Defines a method which may be invoked by PageContextActionFilter allowing controllers
    /// to modify common layout properties of the view model.
    /// </summary>
    internal interface IModifyLayout
    {
        void ModifyLayout(ILayoutModel layoutModel);
    }
}
