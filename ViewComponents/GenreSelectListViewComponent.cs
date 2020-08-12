using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesSample.Models;
using RazorPagesSample.Data;

namespace RazorPagesSample.ViewComponents
{
    public class GenreSelectListViewComponent : ViewComponent
    {
        private readonly RazorPagesMovieContext _context;

        public GenreSelectListViewComponent(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await GetItemsAsync();
            return View(items);
        }
        private Task<List<string>> GetItemsAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            
            return genreQuery.Distinct().ToListAsync();
        }
    }
}