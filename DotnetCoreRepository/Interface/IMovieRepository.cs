using System.Collections.Generic;
using DotnetCoreEntity;

namespace DotnetCoreRepository.Interface
{
    public interface IMovieRepository
    {
        Movie GetById(int id);
        IEnumerable<Movie> GetAll();
        bool Insert(Movie movie);
        bool Update(Movie movie);
        IEnumerable<Movie> GetAllWithGenre();
    }
}