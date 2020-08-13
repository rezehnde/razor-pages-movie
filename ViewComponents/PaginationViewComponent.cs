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
        public PaginatedList<Movie> List { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public int PageSize { get; set; }
        public string PreviousPageUrl { get; set; }
        public string NextPageUrl { get; set; }
        public PaginationViewComponent()
        {
        }
        public IViewComponentResult Invoke(PaginatedList<Movie> list, int pageSize, string currentFilter, string currentSort)
        {
            this.PreviousPageUrl = $"/Movies?pageIndex={ list.PageIndex - 1 }&pageSize={ pageSize }&sortOrder={ currentSort}";
            this.NextPageUrl = $"/Movies?pageIndex={ list.PageIndex + 1 }&pageSize={ pageSize }&sortOrder={ currentSort}";
            this.List = list;
            this.PageSize = pageSize;
            this.CurrentFilter = currentFilter;
            this.CurrentSort = currentSort;
            return View(this);
        }
    }
}
