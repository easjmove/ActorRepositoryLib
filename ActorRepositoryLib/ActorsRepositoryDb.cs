using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLib
{
    public class ActorsRepositoryDB : IActorsRepository
    {
        private readonly ActorsDbContext _context;

        public ActorsRepositoryDB(ActorsDbContext dbContext)
        {
            _context = dbContext;
        }

        public Actor Add(Actor actor)
        {
            actor.Validate();
            actor.Id = 0;
            _context.Actors.Add(actor);
            _context.SaveChanges();
            return actor;
        }

        public Actor? Delete(int Id)
        {
            Actor? actor = GetById(Id);
            if (actor is null)
            {
                return null;
            }
            _context.Actors.Remove(actor);
            _context.SaveChanges();
            return actor;
        }

        public IEnumerable<Actor> Get(string? nameFilter,
            int? minBirthYear,
            int? maxBirthYear,
            int? amount)
        {
            //List<Actor> result = _context.Actors.ToList();
            IQueryable<Actor> query = _context.Actors.AsQueryable();
            return query;
        }

        public Actor? GetById(int id)
        {
            return _context.Actors.FirstOrDefault(m => m.Id == id);
        }

        public Actor? Update(int id, Actor actor)
        {
            actor.Validate();
            Actor? actorToUpdate = GetById(id);
            if (actorToUpdate == null) return null;
            actorToUpdate.Name = actor.Name;
            actorToUpdate.BirthYear = actor.BirthYear;
            _context.SaveChanges();
            return actorToUpdate;
        }
    }
}
