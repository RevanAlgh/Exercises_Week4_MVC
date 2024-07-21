using TheaterApp.Models;
using TheatreApp.Web.Models.DTOs.MoviesDTOs;

namespace TheatreApp.Web.Models.DTOs.AuthorsDTOs
{
    public class UpdateAuthorDto : CreateAuthorDto
    { 
        public int AuthorID { get; set; }
    }
    
}
