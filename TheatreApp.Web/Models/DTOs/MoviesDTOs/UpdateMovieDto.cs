using TheaterApp.Models;

namespace TheatreApp.Web.Models.DTOs.MoviesDTOs
{
    public class UpdateMovieDto : CreateMovieDto
    {
        public int MovieID { get; set; }
    }
}
