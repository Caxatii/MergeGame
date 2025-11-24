using Application.Factories;
using Application.Services.Grid;
using Application.Services.Grid.Cells;
using Application.UseCases.Grid;
using ContractInterfaces.Application.Factories;
using ContractInterfaces.Application.Services;
using ContractInterfaces.Application.UseCases;
using ContractInterfaces.Domain;
using ContractInterfaces.Infrastructure.Services.Grid;
using ContractInterfaces.Infrastructure.View.Grid;
using Domain.Grid.Cells;
using Infrastructure.Repositories.Scriptable.Grid;
using Infrastructure.Services;
using Infrastructure.View.Grid;
using Presentation;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VContainer.Unity;

namespace CompositionRoot
{
    public class GameplayInstaller : LifetimeScope
    {
        [SerializeField] private GridLayoutGroup _parent;
        [SerializeField] private GridElementView _prefab;

        [SerializeField] private GridRepository _gridRepository;
        [SerializeField] private CursorCellView _cursorCellView;
        
        protected override void Configure(IContainerBuilder builder)
        {
            GridModelFactory gridModelFactory = new GridModelFactory();
            GridViewFactory gridViewFactory = new GridViewFactory(_parent, _prefab);

            builder.RegisterInstance<IGridViewSpawner>(gridViewFactory);
            builder.RegisterInstance<IGridModel>(gridModelFactory.Create(_gridRepository));
            builder.RegisterInstance<IGridView>(gridViewFactory.Create(GetSize(_gridRepository)));
            builder.RegisterInstance<ICursorCellView>(_cursorCellView);

            builder.Register<IUnitFactory, UnitFactory>(Lifetime.Singleton);
            builder.Register<ICellPointer, CellPointer>(Lifetime.Singleton).As<CellPointer>();
            
            builder.RegisterEntryPoint<GridInputReader>().As<IGridInputReader>();
            builder.RegisterEntryPoint<GridViewDrawer>().As<IGridDrawer>();
            
            builder.RegisterEntryPoint<GridMergeService>().As<IMergeService>();
            builder.RegisterEntryPoint<GridColorizer>().As<IGridColorizer>();
            builder.RegisterEntryPoint<GridUnitSpawnUseCase>().As<IGridUnitSpawnUseCase>();
            builder.RegisterEntryPoint<GridDrawerService>().As<IGridDrawerService>();
            builder.RegisterEntryPoint<GridPointerMoverService>().As<IGridPointerMoverService>();
            builder.RegisterEntryPoint<GridMergeUseCase>().As<IGridMergeUseCase>();
            builder.RegisterEntryPoint<GridRandomPlaceUseCase>().As<IGridRandomPlaceUseCase>();
            builder.RegisterEntryPoint<CellStateRenderService>().As<ICellStateRenderService>();
            builder.RegisterEntryPoint<CellStateService>().As<ICellStateService>();
            builder.RegisterEntryPoint<CursorCellDrawer>().As<ICursorCellDrawer>();
        }
        
        private Vector2Int GetSize(GridRepository gridRepository)
        {
            return new Vector2Int(gridRepository.Width, gridRepository.Height);
        }
    }
}