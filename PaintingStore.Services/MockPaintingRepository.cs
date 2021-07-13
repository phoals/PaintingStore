﻿using PaintingStore.Models;
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
        public IEnumerable<Painting> GetAllPaintings()
        {
            return _paintingList;
        }

        public Painting GetPainting(int id)
        {
            return _paintingList.FirstOrDefault(x => x.Id == id);
        }
    }
}