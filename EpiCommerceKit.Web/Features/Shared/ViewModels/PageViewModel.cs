using EpiCommerceKit.Web.Features.Shared.ViewModels.Interfaces;
using EPiServer.Core;
using System.Collections.Generic;

namespace EpiCommerceKit.Web.Features.Shared.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : IContent
    {
        public PageViewModel(T currentPage)
        {
            ErrorText = new List<string>();
            CurrentPage = currentPage;
        }

        protected PageViewModel()
        {
        }

        public T CurrentPage { get; set; }

        public string PageURL { get; set; }

        public IContent Section { get; set; }

        public int PageNumber { get; set; }

        public ILayoutModel Layout { get; set; }

        public List<string> ErrorText { get; set; }
    }

    public static class PageViewModel
    {
        /// <summary>
        /// Returns a PageViewModel of type <typeparam name="T"/>.
        /// </summary>
        /// <remarks>
        /// Convenience method for creating PageViewModels without having to specify the type as methods can use type inference while constructors cannot.
        /// </remarks>
        public static PageViewModel<T> Create<T>(T page) where T : IContent
        {
            return new PageViewModel<T>(page);
        }
    }

}