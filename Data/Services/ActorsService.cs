using Microsoft.EntityFrameworkCore;
using project_asp.Data.Base;
using project_asp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace project_asp.Data.Services
{
    public class ActorsService: EntityBaseRepository<Actor> , IActorsService
    {
       

        public ActorsService(AppDbContext context) : base(context) { }
        

        
    }
}
