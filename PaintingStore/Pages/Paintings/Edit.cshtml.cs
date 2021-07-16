using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaintingStore.Models;
using PaintingStore.Services;
using Microsoft.Net.Http;

namespace PaintingStore.Pages.Paintings
{
    public class EditModel : PageModel
    {
        private readonly IPaintingRepository _paintingRepository;

        public Painting Painting { get; set; }

        public EditModel(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
        }

        public IActionResult OnGet(int id)
        {
            Painting = _paintingRepository.GetPainting(id);

            if (Painting == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Painting painting)
        {
            Painting = _paintingRepository.Update(painting);

            return RedirectToPage("Paintings");
        }
    }
}
