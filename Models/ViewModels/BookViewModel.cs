using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Models.ViewModels
{

    public class BookViewModel
    {
        public Book Book { get; set; }
        public string AuthorName { get; set; }
        public SelectList Authors { get; set; }
    }

}
