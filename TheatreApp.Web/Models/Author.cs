
using TheaterApp.Models;

namespace MovieApi.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public ICollection<MovieAuthor> MovieAuthors { get; set; } = new List<MovieAuthor>();
    }
}