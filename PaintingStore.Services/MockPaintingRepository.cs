using PaintingStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PaintingStore.Services
{
    public class MockPaintingRepository : IPaintingRepository
    {
        private List<Painting> _paintingList;

        public MockPaintingRepository()
        {
            _paintingList = new List<Painting>()
            {
                new Painting()
                {
                    Id = 0, Name = "The scream", Author = "Edward Monk", Cost = 0, Genre = Genre.None, Photopath = "scream.png"
                },
                new Painting()
                {
                    Id = 1, Name = "Girl with a pearl earring", Author = "Johannes Vermeer", Cost = 0, Genre = Genre.Portrait, Photopath = "pearl.png"
                },
                new Painting()
                {
                    Id = 2, Name = "Mona Lisa", Author = "Leonardo da Vinci", Cost = 0, Genre = Genre.Portrait, Photopath = "mona.png"
                },
                new Painting()
                {
                    Id = 3, Name = "Starry night", Author = "Van Gogh", Cost = 0, Genre = Genre.Landscape, Photopath = "night.png"
                },
                new Painting()
                {
                    Id = 4, Name = "Still life with apples", Author = "Paul Cézanne", Cost = 0, Genre = Genre.StillLife, Photopath = "apples.png"
                },
                new Painting()
                {
                    Id = 5, Name = "Yellow-Red-Blue", Author = "Wassily Kandinsky", Cost = 0, Genre = Genre.Abstraction, Photopath = "yellow.png"
                }
            };
        }

        public Painting Add(Painting newPainting)
        {
            newPainting.Id = _paintingList.Max(x => x.Id) + 1;
            _paintingList.Add(newPainting);

            return newPainting;
        }

        public Painting Delete(int id)
        {
            Painting paintingToDelete = _paintingList.FirstOrDefault(x => x.Id == id);

            if (paintingToDelete != null)
            {
                _paintingList.Remove(paintingToDelete);
            }

            return paintingToDelete;
        }

        public IEnumerable<Painting> GetAllPaintings()
        {
            return _paintingList;
        }

        public Painting GetPainting(int id)
        {
            return _paintingList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GenrePaintingCount> PaintingCountByGenre()
        {
            return _paintingList.GroupBy(x => x.Genre)
                                .Select(x => new GenrePaintingCount()
                                {
                                    Genre = x.Key.Value,
                                    Count = x.Count()
                                }).ToList();
        }   

        public Painting Update(Painting updatedPainting)
        {
            Painting painting = _paintingList.FirstOrDefault(x => x.Id == updatedPainting.Id);

            if (painting != null)
            {
                painting.Name = updatedPainting.Name;
                painting.Author = updatedPainting.Author;
                painting.Cost = updatedPainting.Cost;
                painting.Genre = updatedPainting.Genre;
                painting.Photopath = updatedPainting.Photopath;
            }

            return painting;
        }
    }
}
