using _Source.ContractInterfaces.Domain;
using _Source.ContractInterfaces.Repositories;

namespace _Source.ContractInterfaces.Application.Factories
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