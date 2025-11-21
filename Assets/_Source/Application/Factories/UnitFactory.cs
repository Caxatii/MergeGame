using System;
using ContractInterfaces.Application.Factories;
using ContractInterfaces.Domain;
using Domain;
using Domain.Grid;

namespace Application.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit Create(Guid id)
        {
            return new Unit(id);
        }
    }
}