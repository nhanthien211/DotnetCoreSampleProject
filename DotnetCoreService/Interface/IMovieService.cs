using System;
using System.Collections.Generic;
using System.Text;
using DotnetCoreEntity;
using DotnetCoreService.DTO;

namespace DotnetCoreService.Interface
{
    public interface IMovieService
    {
        Movie GetMovieInfo(int id);
        List<Movie> GetAllMovie();
        bool CreateMovie(MovieDto movie);
        bool UpdateMovie(Movie movie);
    }
}
