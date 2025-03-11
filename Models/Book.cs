using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{

    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Genre { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Range(0, int.MaxValue)]
        public int CopiesAvailable { get; set; }
    }


}
