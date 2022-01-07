using eCommerce.Data.Base;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.Services
{
    public class ActorService : EntityBaseRepository<Actor>, IActorService
    {
        public ActorService(AppDbContext context): base(context) { }
       
    }
}
