using System;
using System.Collections.Generic;
using System.Text;
using PaintingStore.Models;

namespace PaintingStore.Services
{
    public interface IBasketRepository
    {
        IEnumerable<Painting> GetAllBasket();

        List<Painting> AddToBasket(int id);
    }
}
