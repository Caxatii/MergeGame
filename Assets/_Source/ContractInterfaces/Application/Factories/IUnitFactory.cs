using System;
using ContractInterfaces.Domain;

namespace ContractInterfaces.Application.Factories
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