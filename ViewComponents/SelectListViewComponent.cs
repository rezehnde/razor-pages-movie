using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesSample.Models;
using RazorPagesSample.Data;
using System.Web.Mvc;

namespace RazorPagesSample.ViewComponents
{
    public class SelectListViewComponent : ViewComponent
    {
        private readonly RazorPagesMovieContext _context;
        public string Name { get; set; }
        public List<string> List { get; set; }
        public SelectListViewComponent(RazorPagesMovieContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string name)
        {
            this.Name = name;
            this.List = await GetItemsAsync();
            return View(this);
        }
        private Task<List<string>> GetItemsAsync()
        {
            return _context.Movie.OrderBy(x => x.Genre).Select(x => x.Genre).Distinct().ToListAsync();
        }
    }
}