using ContractInterfaces.Domain;
using ContractInterfaces.Repositories;
using ContractInterfaces.Repositories.Grid;

namespace ContractInterfaces.Application.Factories
{
    public interface IGridModelFactory
    {
        public IGridModel Create(IGridRepository repository);
    }

    // public interface IGridModelFactory<T> : IGridModelFactory where T : IUnit
    // {
    //     public new IGridModel<T> Create(IGridRepository repository);
    // }
}