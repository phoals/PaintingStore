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
        [MaxLength(50), MinLength(1)]
        public string Name { get; set; }

        [MaxLength(50), MinLength(1)]
        public string Author { get; set; }

        public int Cost { get; set; }

        public string Photopath { get; set; }

        public Genre? Genre { get; set; }
    }
}
