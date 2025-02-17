using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishedDate { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
    }
}