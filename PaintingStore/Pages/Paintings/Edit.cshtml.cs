using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PaintingStore.Models;
using PaintingStore.Services;
using Microsoft.Net.Http;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace PaintingStore.Pages.Paintings
{
    public class EditModel : PageModel
    {
        private readonly IPaintingRepository _paintingRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        [BindProperty]
        public int MaxPaintingId { get; set; }

        [BindProperty]
        public int NewPaintingId { get; set; }

        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public Painting Painting { get; set; }

        [BindProperty]
        public IEnumerable<Painting> Paintings { get; set; }

        public EditModel(IPaintingRepository paintingRepository, IWebHostEnvironment webHostEnvironment)
        {
            _paintingRepository = paintingRepository;
            _webHostEnvironment = webHostEnvironment;
            Paintings = _paintingRepository.GetAllPaintings();
            if (Paintings.Count() > 0)
            {
                MaxPaintingId = Paintings.Max(x => x.Id);
            }
            else
            {
                MaxPaintingId = 0;
            }
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Painting = _paintingRepository.GetPainting(id.Value);
            }
            else
            {
                Painting = new Painting();
                NewPaintingId = MaxPaintingId + 1;
            }

            if (Painting == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Photo != null)
                {
                    Painting.Photopath = ProcessUploadedFile();
                }

                if (NewPaintingId > MaxPaintingId)
                {
                    Painting = _paintingRepository.Add(Painting);
                }
                else
                {
                    Painting = _paintingRepository.Update(Painting);
                }

                return RedirectToPage("Paintings");
            }

                return Page();
        }

        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }

            return uniqueFileName;
        }
    }
}
