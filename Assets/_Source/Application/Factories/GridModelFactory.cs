using _Source.ContractInterfaces.Application.Factories;
using _Source.ContractInterfaces.Domain;
using _Source.ContractInterfaces.Repositories;
using _Source.Domain;

namespace _Source.Application.Factories
{
    public class GridModelFactory : IGridModelFactory
    {
        public IGridModel Create(IGridRepository repository)
        {
            return new GridModel<Unit>(repository.Width, repository.Height);
        }
    }
}