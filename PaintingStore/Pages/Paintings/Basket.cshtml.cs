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
    public class BasketModel : PageModel
    {
        private readonly IPaintingRepository _paintingRepository;

        public List<Painting> paintingsInBasket;

        public BasketModel(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
            paintingsInBasket = new List<Painting>();
        }

        public Painting Painting { get; set; }

        public IActionResult OnGet(int id)
        {
            Painting = _paintingRepository.GetPainting(id);
            this.paintingsInBasket.Add(Painting);

            return Page();
        }
    }
}
