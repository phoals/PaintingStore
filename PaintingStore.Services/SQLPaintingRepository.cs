using PaintingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaintingStore.Services
{
    public class SQLPaintingRepository : IPaintingRepository
    {
        private readonly AppDbContext _context;

        public SQLPaintingRepository(AppDbContext context)
        {
            _context = context;
        }

        public Painting Add(Painting newPainting)
        {
            _context.Paintings.Add(newPainting);
            _context.SaveChanges();

            return newPainting;
        }

        public Painting Delete(int id)
        {
            var paintingToDelete = _context.Paintings.Find(id);

            if (paintingToDelete != null)
            {
                _context.Paintings.Remove(paintingToDelete);
                _context.SaveChanges();
            }

            return paintingToDelete;
        }

        public IEnumerable<Painting> GetAllPaintings()
        {
            return _context.Paintings;
        }

        public Painting GetPainting(int id)
        {
            return _context.Paintings.Find(id);
        }

        public IEnumerable<GenrePaintingCount> PaintingCountByGenre()
        {
            return _context.Paintings.GroupBy(x => x.Genre)
                                .Select(x => new GenrePaintingCount()
                                {
                                    Genre = x.Key.Value,
                                    Count = x.Count()
                                }).ToList();
        }

        public IEnumerable<Painting> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _context.Paintings;
            }

            return _context.Paintings.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower()) || x.Author.ToLower().Contains(searchTerm.ToLower()));
        }

        public Painting Update(Painting updatedPainting)
        {
            var painting = _context.Paintings.Attach(updatedPainting);
            painting.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();

            return updatedPainting;
        }
    }
}
