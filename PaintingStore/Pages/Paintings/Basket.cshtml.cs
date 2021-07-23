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
        private readonly IBasketRepository _basketRepository;
        public List<Painting> paintingsInBasket;
        public int quantity;

        public BasketModel(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                paintingsInBasket = _basketRepository.AddToBasket(id.Value);
                quantity = paintingsInBasket.Count();
            }
            else
            {
                paintingsInBasket = _basketRepository.GetAllBasket();
            }

            return Page();
        }
    }
}
