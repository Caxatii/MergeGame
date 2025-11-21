using ContractInterfaces.Application.Factories;
using ContractInterfaces.Domain;
using ContractInterfaces.Repositories;
using ContractInterfaces.Repositories.Grid;
using Domain;
using Domain.Grid;

namespace Application.Factories
{
    public class GridModelFactory : IGridModelFactory
    {
        public IGridModel Create(IGridRepository repository)
        {
            return new GridModel<Unit>(repository.Width, repository.Height);
        }
    }
}