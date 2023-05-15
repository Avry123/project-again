using project_asp.Data.Base;
using project_asp.Models;

namespace project_asp.Data.Services
{
    public class ProducersService: EntityBaseRepository<Producer>, iProducersService
    {
        public ProducersService(AppDbContext context) : base(context)
        {
            
        }
    }
}
