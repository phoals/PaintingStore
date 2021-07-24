using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaintingStore.Models;
using PaintingStore.Services;

namespace PaintingStore.Pages.Paintings
{
    public class PaintingsModel : PageModel
    {
        private readonly IPaintingRepository _db;

        public PaintingsModel(IPaintingRepository db)
        {
            _db = db;
        }

        public IEnumerable<Painting> Paintings { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        public void OnGet()
        {
            Paintings = _db.Search(SearchTerm);
        }
    }
}
