using Microsoft.EntityFrameworkCore;
using project_asp.Data.Base;
using project_asp.Models;
using System.Linq.Expressions;

namespace project_asp.Data.Services
{
    public class MoviesService:EntityBaseRepository<Movie>, IMoviesService
    {

        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context): base(context)
        {
            _context = context;
        }

         public async Task<Movie> GetMovieByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties)
         {
             var moviesDetails = await _context.Movies
                                 .Include(c => c.Cinema)
                                 .Include(p => p.Producer)
                                 .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                                 .FirstOrDefaultAsync(n => n.Id == id);

             return  moviesDetails;
         } 

      /*  public async Task<Movie> GetByIdAsync(int id, params Expression<Func<Movie, object>>[] includeProperties)
        {
            var query = _context.Movies.AsQueryable();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var movie = await query.FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        } */

    }
}
