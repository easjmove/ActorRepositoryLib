using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActorRepositoryLib
{
    public class ActorsRepositoryList : IActorsRepository
    {
        private List<Actor> _actors;
        private int _nextId;

        public ActorsRepositoryList()
        {
            _nextId = 1;
            _actors = new List<Actor>() {
                new Actor() { Id = _nextId++, Name = "Johnny Depp", BirthYear=1963 },
                new Actor() { Id = _nextId++, Name = "Vin Diesel", BirthYear=1967 },
                new Actor() { Id = _nextId++, Name = "Dwayne Johnson", BirthYear=1972 }
            };
        }

        public IEnumerable<Actor> Get(string? nameFilter,
            int? minBirthYear,
            int? maxBirthYear,
            int? amount)
        {
            List<Actor> query = new List<Actor>(_actors);
            
            if (nameFilter != null)
            {
                query = query.FindAll(actor => 
                actor.Name.Contains(nameFilter,
                StringComparison.InvariantCultureIgnoreCase
                ));
            }

            if (minBirthYear != null)
            {
                query = query.FindAll(actor => 
                actor.BirthYear >= minBirthYear);
            }

            if (maxBirthYear != null)
            {
                query = query.FindAll(actor =>
                actor.BirthYear <= maxBirthYear);
            }

            if (amount != null)
            {
                query = query.Take(amount.Value).ToList();
            }
            
            return query;
        }

        public Actor? GetById(int id)
        {
            return _actors.Find(actor => actor.Id == id);
        }

        public Actor Add(Actor newActor)
        {
            newActor.Validate();
            newActor.Id = _nextId++;
            _actors.Add(newActor);
            return newActor;
        }

        public Actor? Delete(int Id)
        {
            Actor? toBeDeleted = GetById(Id);
            if (toBeDeleted != null)
            {
                _actors.Remove(toBeDeleted);
            }
            return toBeDeleted;
        }

        public Actor? Update(int Id, Actor updates)
        {
            updates.Validate();
            Actor? toBeUpdated = GetById(Id);
            if (toBeUpdated != null)
            {
                toBeUpdated.Name = updates.Name;
                toBeUpdated.BirthYear = updates.BirthYear;
            }
            return toBeUpdated;
        }
    }
}
