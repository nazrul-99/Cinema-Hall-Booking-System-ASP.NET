using eCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Data.Services
{
    public interface IActorService
    {
        Task<IEnumerable<Actor>> GetAll();
        Task<Actor> GetByIdAsync(int id);
        Task AddAsync(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor newActor);
        void Delete(int id);

    }
}
