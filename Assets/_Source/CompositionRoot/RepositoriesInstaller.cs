using ContractInterfaces.Repositories.Grid;
using ContractInterfaces.Repositories.Grid.Cell;
using ContractInterfaces.Repositories.Merge;
using Infrastructure.Repositories.Collections.Grid;
using Infrastructure.Repositories.Collections.Merge;
using Infrastructure.Repositories.Scriptable.Grid;
using Infrastructure.Repositories.Scriptable.Merge;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace CompositionRoot
{
    public class RepositoriesInstaller : LifetimeScope
    {
        [SerializeField] private GridElementRepositoryContainer _elementRepositoryContainer;
        [SerializeField] private MergeRepositoryContainer _mergeResultRepositoryContainer;
        [SerializeField] private GridColorizeRepositoryContainer _colorizeRepositoryContainer;
        
        protected override void Configure(IContainerBuilder builder)
        {
            var elementCollection = new GridElementRepositoryCollection(_elementRepositoryContainer.Get());
            var mergeCollection = new MergeRepositoryCollection(_mergeResultRepositoryContainer.Get());
            var colorizeCollection = new GridColorizeRepositoryCollection(_colorizeRepositoryContainer.Get());

            builder.RegisterInstance<IGridElementRepositoryCollection>(elementCollection);
            builder.RegisterInstance<ICellColorizeRepositoryCollection>(colorizeCollection);
            builder.RegisterInstance<IMergeRepositoryCollection>(mergeCollection);
        }
    }
}