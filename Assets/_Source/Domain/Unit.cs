using System;
using _Source.ContractInterfaces.Domain;

namespace _Source.Domain
{
    public class Unit : IUnit
    {
        public Unit(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}