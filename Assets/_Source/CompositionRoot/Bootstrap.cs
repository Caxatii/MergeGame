using Application.Factories;
using Application.Services.Grid;
using Application.Services.Grid.Cells;
using Application.UseCases.Grid;
using ContractInterfaces.Domain;
using ContractInterfaces.Infrastructure.View.Grid;
using Domain.Grid.Cells;
using Infrastructure.Repositories.Collections.Grid;
using Infrastructure.Repositories.Collections.Merge;
using Infrastructure.Repositories.Scriptable.Grid;
using Infrastructure.Repositories.Scriptable.Merge;
using Infrastructure.View.Grid;
using Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace CompositionRoot
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private float _autoSpawnDelay;

        [SerializeField] private GridRepository _gridRepository;
        [SerializeField] private GridElementView _gridElementView;
        [SerializeField] private GridLayoutGroup _layoutGroup;

        [SerializeField] private GridElementRepositoryContainer _elementRepositoryContainer;
        [SerializeField] private MergeRepositoryContainer _mergeResultRepositoryContainer;

        [SerializeField] private GridElementRepository _spawnUnit;
        [SerializeField] private GridColorizeRepositoryContainer _colorizeRepositoryContainer;

        private readonly GridModelFactory _factory = new GridModelFactory();
        private readonly CellPointer _pointer = new CellPointer();
        
        private CellStateRenderService _cellStateRenderService;
        private CellStateService _cellStateService;
        private GridColorizeRepositoryCollection _colorizeCollection;
        private GridColorizer _colorizer;

        private GridViewDrawer _drawer;

        private GridDrawerService _drawerService;

        private GridElementRepositoryCollection _elementCollection;

        private GridMergeUseCase _gridMergeUseCase;
        private GridInputReader _inputReader;
        private MergeRepositoryCollection _mergeCollection;
        private GridMergeService _mergeService;
        private GridPointerMoverService _pointerMoverService;
        private GridRandomPlaceUseCase _randomPlaceUseCase;
        private GridUnitSpawnUseCase _unitSpawnUseCase;

        private GridViewFactory _viewFactory;

        private void Awake()
        {
            _elementCollection = new GridElementRepositoryCollection(_elementRepositoryContainer.Get());
            _mergeCollection = new MergeRepositoryCollection(_mergeResultRepositoryContainer.Get());
            _colorizeCollection = new GridColorizeRepositoryCollection(_colorizeRepositoryContainer.Get());

            _viewFactory = new GridViewFactory(_layoutGroup, _gridElementView);

            IGridModel gridModel = _factory.Create(_gridRepository);
            IGridView gridView = _viewFactory.Create(new Vector2Int(gridModel.Width, gridModel.Height));
            var unitFactory = new UnitFactory();

            _inputReader = new GridInputReader(gridView);
            _drawer = new GridViewDrawer(_elementCollection, gridView);
            _colorizer = new GridColorizer(gridView);

            _unitSpawnUseCase = new GridUnitSpawnUseCase(gridModel, unitFactory);

            _drawerService = new GridDrawerService(gridModel, _drawer);
            _mergeService = new GridMergeService(gridModel, _mergeCollection, _unitSpawnUseCase);
            _pointerMoverService = new GridPointerMoverService(_pointer, _inputReader);
            _cellStateService = new CellStateService(gridModel, _pointer, _mergeService);

            _cellStateRenderService = new CellStateRenderService(_cellStateService,
                _pointer,
                _colorizeCollection,
                _colorizer,
                gridModel);

            _gridMergeUseCase = new GridMergeUseCase(_mergeService, _pointer, gridModel);
            _randomPlaceUseCase = new GridRandomPlaceUseCase(gridModel, _unitSpawnUseCase);

            Initialize();
        }

        private void Start()
        {
            SpawnUnit();
            Invoke(nameof(Start), _autoSpawnDelay);
        }

        private void Initialize()
        {
            _inputReader.Initialize();

            _drawerService.Initialize();
            _mergeService.Initialize();
            _gridMergeUseCase.Initialize();
            _pointerMoverService.Initialize();
            _cellStateRenderService.Initialize();
        }

        [ContextMenu("Spawn Unit")]
        private void SpawnUnit()
        {
            _randomPlaceUseCase.Spawn(_spawnUnit.Id);
        }
    }
}