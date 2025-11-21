using System;
using ContractInterfaces.Domain;

namespace Domain.Grid
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