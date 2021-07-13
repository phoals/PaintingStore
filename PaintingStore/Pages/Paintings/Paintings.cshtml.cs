using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public void OnGet()
        {
            Paintings = _db.GetAllPaintings();
        }
    }
}
