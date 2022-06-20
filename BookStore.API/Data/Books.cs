using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Data
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }
        public int Title { get; set; }
        public string Desctription { get; set; }

    }
}
