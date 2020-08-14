using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesSample.Models;
using RazorPagesSample.Data;
using System.Web.Mvc;
using RazorPagesSample.Pages;
using System;

namespace RazorPagesSample.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string PreviousPageUrl { get; set; }
        public string NextPageUrl { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool HasNextPage { get; set; }
        public PaginationViewComponent()
        {
        }
        public IViewComponentResult Invoke(int pageIndex, int pageSize, string currentFilter, string currentSort, bool hasPreviousPage, bool hasNextPage)
        {
            this.PreviousPageUrl = $"/Movies?pageIndex={ pageIndex - 1 }&pageSize={ pageSize }&sortOrder={ currentSort}";
            this.NextPageUrl = $"/Movies?pageIndex={ pageIndex + 1 }&pageSize={ pageSize }&sortOrder={ currentSort}";
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.HasPreviousPage = hasPreviousPage;
            this.HasNextPage = hasNextPage;
            this.CurrentFilter = currentFilter;
            this.CurrentSort = currentSort;
            return View(this);
        }
    }
}
