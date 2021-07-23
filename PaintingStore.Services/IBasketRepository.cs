using System;
using System.Collections.Generic;
using System.Text;
using PaintingStore.Models;

namespace PaintingStore.Services
{
    public interface IBasketRepository
    {
        List<Painting> GetAllBasket();

        List<Painting> AddToBasket(int id);
    }
}
