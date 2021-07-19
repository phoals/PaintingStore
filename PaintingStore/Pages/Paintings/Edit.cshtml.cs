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
        public IFormFile Photo { get; set; }

        public Painting Painting { get; set; }

        public EditModel(IPaintingRepository paintingRepository, IWebHostEnvironment webHostEnvironment)
        {
            _paintingRepository = paintingRepository;
            _webHostEnvironment = webHostEnvironment;
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
            if (Photo != null)
            {
                if (painting.Photopath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", painting.Photopath);
                    System.IO.File.Delete(filePath);
                }

                painting.Photopath = ProcessUploadedFile();
            }

            Painting = _paintingRepository.Update(painting);

            return RedirectToPage("Paintings");
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
