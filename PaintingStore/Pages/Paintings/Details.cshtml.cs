using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaintingStore.Services;
using PaintingStore.Models;

namespace PaintingStore.Pages.Paintings
{
    public class DetailsModel : PageModel
    {
        private readonly IPaintingRepository _paintingRepository;

        public DetailsModel(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        public Painting painting { get; private set; }

        public IActionResult OnGet(int id)
        {
            painting = _paintingRepository.GetPainting(id);

            if (painting == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }
    }
}
