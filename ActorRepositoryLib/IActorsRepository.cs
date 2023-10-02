﻿
namespace ActorRepositoryLib
{
    public interface IActorsRepository
    {
        Actor Add(Actor newActor);
        Actor? Delete(int Id);
        IEnumerable<Actor> Get(int? amount);
        Actor? GetById(int id);
        Actor? Update(int Id, Actor updates);
    }
}