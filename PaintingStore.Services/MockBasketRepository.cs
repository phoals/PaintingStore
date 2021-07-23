using PaintingStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaintingStore.Services
{
    public class MockBasketRepository : IBasketRepository
    {
        List<Painting> _paintingsBasket;
        IPaintingRepository _paintingRepository;

        public MockBasketRepository(IPaintingRepository paintingRepository)
        {
            _paintingRepository = paintingRepository;
            _paintingsBasket = new List<Painting>();
        }
        public List<Painting> GetAllBasket()
        {
            return _paintingsBasket;
        }

        public List<Painting> AddToBasket(int id)
        {
            var painting = _paintingRepository.GetPainting(id);
            _paintingsBasket.Add(painting);

            return _paintingsBasket;
        }
    }
}
