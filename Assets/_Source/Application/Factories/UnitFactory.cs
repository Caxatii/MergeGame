using System;
using _Source.ContractInterfaces.Application.Factories;
using _Source.ContractInterfaces.Domain;
using _Source.Domain;

namespace _Source.Application.Factories
{
    public class UnitFactory : IUnitFactory
    {
        public IUnit Create(Guid id)
        {
            return new Unit(id);
        }
    }
}