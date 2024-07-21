using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TheaterApp.Models;

namespace TheatreApp.Web.Models.DTOs.MoviesDTOs
{
    public class CreateMovieDto
    {
            public string MovieTitle { get; set; }
            public float ImdbRating { get; set; }
            public int YearReleased { get; set; }
            public decimal Budget { get; set; }
            public decimal BoxOffice { get; set; }
            public string Language { get; set; }
            public int AuthorID { get; set; }
    }

    }
