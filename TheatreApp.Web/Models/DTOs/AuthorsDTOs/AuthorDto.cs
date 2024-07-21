using TheaterApp.Models;

namespace TheatreApp.Web.Models.DTOs.AuthorsDTOs
{
    public class AuthorDto : UpdateAuthorDto
    {
        public List<MovieAuthor> MovieAuthors { get; set; }
    }
}
