using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreB
{
    public class Book
    {
        //Auto Increment ID kolonunun eklenmesi
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
