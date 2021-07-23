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
    public class DeleteModel : PageModel
    {
        private readonly IPaintingRepository _paintingRepository;

        public DeleteModel(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        [BindProperty]
        public Painting Painting { get; set; }

        public IActionResult OnGet(int id)
        {
            Painting = _paintingRepository.GetPainting(id);

            if (Painting == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Painting deletedPainting = _paintingRepository.Delete(Painting.Id);

            if (deletedPainting == null)
            {
                return RedirectToPage("/NotFound");
            }

            return RedirectToPage("Paintings");
        }
    }
}
