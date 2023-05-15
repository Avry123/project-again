using project_asp.Data.Base;
using project_asp.Models;
using System.Linq.Expressions;

namespace project_asp.Data.Services
{
    public interface IMoviesService:IEntityBaseRepository<Movie>
    {
     //  Task<Movie> GetMovieByIdAsync(int id);

         Task<Movie> GetMovieByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties);

    }
}
