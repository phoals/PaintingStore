using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaintingStore.Models
{
    public class Painting
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field can not be null")]
        public string Name { get; set; }
     
        public string Author { get; set; }

        public int Cost { get; set; }

        public string Photopath { get; set; }

        public Genre? Genre { get; set; }
    }
}
