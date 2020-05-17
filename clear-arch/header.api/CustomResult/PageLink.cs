namespace api.CustomResult
{
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Defines the <see cref="PageLink{T}" />.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    public sealed class PageLink<T> where T : PaginatedQueryResponseBase
    {
        /// <summary>
        /// Prevents a default instance of the <see cref="PageLink{T}"/> class from being created.
        /// </summary>
        /// <param name="result">The result<see cref="T"/>.</param>
        /// <param name="url">The url<see cref="IUrlHelper"/>.</param>
        private PageLink(T result, IUrlHelper url)
        {
            FirstPage = url.RouteUrl(new { pageNumber = 1, pageSize = result.Paging.PageSize });
            LastPage = url.RouteUrl(new { pageNumber = result.Paging.PageCount, pagesiZe = result.Paging.PageSize });
            PreviousPage = url.RouteUrl(new { pageNumber = result.Paging.PageNo - 1, pageSize = result.Paging.PageSize });
            NextPage = url.RouteUrl(new { pageNumber = result.Paging.PageNo + 1, pageSize = result.Paging.PageSize });
            Result = result;
        }

        /// <summary>
        /// The Create.
        /// </summary>
        /// <param name="url">The url<see cref="IUrlHelper"/>.</param>
        /// <param name="pagedResult">The pagedResult<see cref="T"/>.</param>
        /// <returns>The <see cref="PageLink{T}"/>.</returns>
        public static PageLink<T> Create(IUrlHelper url, T pagedResult)
        {
            return new PageLink<T>(pagedResult, url);
        }

        /// <summary>
        /// Gets the Result.
        /// </summary>
        public T Result { get; }

        /// <summary>
        /// Gets the FirstPage.
        /// </summary>
        public string FirstPage { get; }

        /// <summary>
        /// Gets the LastPage.
        /// </summary>
        public string LastPage { get; }

        /// <summary>
        /// Gets the NextPage.
        /// </summary>
        public string NextPage { get; }

        /// <summary>
        /// Gets the PreviousPage.
        /// </summary>
        public string PreviousPage { get; }
    }
}