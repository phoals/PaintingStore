using System;
using System.Collections.Generic;
using System.Text;
using PaintingStore.Models;

namespace PaintingStore.Services
{
    public interface IPaintingRepository
    {
        IEnumerable<Painting> GetAllPaintings();

        Painting GetPainting(int id);

        Painting Update(Painting updatedPainting);

        Painting Add(Painting newPainting);
    }
}
