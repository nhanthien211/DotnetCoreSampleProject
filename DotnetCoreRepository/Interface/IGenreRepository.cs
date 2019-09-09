using DotnetCoreEntity;

namespace DotnetCoreRepository.Interface
{
    public interface IGenreRepository
    {
        bool Insert(Genre genre);
    }
}