﻿using System;
using System.Collections.Generic;
using System.Text;
using PaintingStore.Models;

namespace PaintingStore.Services
{
    public interface IPaintingRepository
    {
        IEnumerable<Painting> Search(string searchTerm);

        IEnumerable<Painting> GetAllPaintings();

        Painting GetPainting(int id);

        Painting Update(Painting updatedPainting);

        Painting Add(Painting newPainting);

        Painting Delete(int id);

        IEnumerable<GenrePaintingCount> PaintingCountByGenre();
    }
}
