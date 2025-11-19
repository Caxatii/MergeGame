using System;
using _Source.ContractInterfaces.Domain;

namespace _Source.ContractInterfaces.Application.Factories
{
    public interface IUnitFactory
    {
        public IUnit Create(Guid id);
    }

    public interface IUnitFactory<out T> : IUnitFactory where T : IUnit
    {
        public new T Create(Guid id);
    }
}