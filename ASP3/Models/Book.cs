using System.ComponentModel.DataAnnotations;

namespace ASP3.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public Author Author { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Ціна повинна бути більшою за 0")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Кількість сторінок повинна бути більшою за 0")]
        public int Pages { get; set; }
    }
}
