using project_asp.Data.Base;
using project_asp.Models;

namespace project_asp.Data.Services
{
    public class CinemasService:EntityBaseRepository<Cinema>, ICinemaService
    {
        public CinemasService(AppDbContext context) : base(context)
        {
            
        }
    }
}
