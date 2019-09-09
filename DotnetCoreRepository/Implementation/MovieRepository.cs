using System.Collections.Generic;
using System.Data;
using System.Transactions;
using Dapper;
using DotnetCoreEntity;
using DotnetCoreRepository.Interface;

namespace DotnetCoreRepository.Implementation
{
    public class MovieRepository : IMovieRepository
    {
        private IUnitOfWork _unitOfWork;

        public MovieRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Movie GetById(int id)
        {
            string sql = "select * from movie where id = @id";
            var param = new DynamicParameters();
            param.Add("@id", id);
            return _unitOfWork.Connection.QuerySingle<Movie>(sql, param);
        }

        public IEnumerable<Movie> GetAll()
        {
            string sql = "select * from movie";
            return _unitOfWork.Connection.Query<Movie>(sql);
        }

        public IEnumerable<Movie> GetAllWithGenre()
        {
            string sql = "select m.Id, m.Name, m.genreid, g.Name from movie m inner join genre g on m.genreid = g.id";

            var result = _unitOfWork.Connection.Query<Movie, Genre, Movie>
            (
                sql,
                (movie, genre) =>
                {
                    movie.Genre = genre;
                    return movie;
                },
                splitOn: "genreid"
            //The splitOn parameter should be understood something like this:
            //If all columns are arranged from left to right in the order in the query,
            //then the values on the left belong to the first class and the values on the right belong to the second class.
            );
            return result;
        }

        public bool Insert(Movie movie)
        {
            string sql = "insert into movie(name, genreid) values (@name, @genreid)";

            var param = new DynamicParameters();
            param.Add("@name", movie.Name);
            param.Add("@genreid", movie.GenreId);

            var result = _unitOfWork.Connection.Execute(sql, param, transaction: _unitOfWork.Transaction);

            return result > 0;
        }

        public bool Update(Movie movie)
        {
            string sql = "update movie set name = @name where id = @id";
            var param = new DynamicParameters();
            param.Add("@name", movie.Name);
            param.Add("@id", movie.Id);

            var result = _unitOfWork.Connection.Execute(sql, param, _unitOfWork.Transaction);
            return result > 0;
        }
    }
}
