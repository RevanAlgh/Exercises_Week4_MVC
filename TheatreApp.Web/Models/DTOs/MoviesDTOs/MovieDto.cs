using TheaterApp.Models;

namespace TheatreApp.Web.Models.DTOs.MoviesDTOs
{
    public class MovieDto : UpdateMovieDto
    {
        public List<MovieAuthor> MovieAuthors { get; set; }
    }
}
