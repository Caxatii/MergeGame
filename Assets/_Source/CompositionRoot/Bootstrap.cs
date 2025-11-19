using System;
using _Source.Application;
using _Source.Application.Factories;
using _Source.ContractInterfaces.Domain;
using _Source.ContractInterfaces.Infrastructure;
using _Source.Domain;
using _Source.Infrastructure;
using _Source.Infrastructure.Repositories;
using _Source.Infrastructure.Repositories.Collections;
using _Source.Presentation;
using UnityEngine;
using UnityEngine.UI;

namespace _Source.CompositionRoot
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private float _autoSpawnDelay;
        
        [SerializeField] private GridRepository _gridRepository;
        [SerializeField] private GridElementView _gridElementView;
        [SerializeField] private GridLayoutGroup _layoutGroup;

        [SerializeField] private GridElementRepositoryContainer _elementRepositoryContainer;
        [SerializeField] private MergeRepositoryContainer _mergeResultRepositoryContainer;

        [SerializeField] private GridColorizeRepositoryContainer _colorizeRepositoryContainer;

        [SerializeField] private GridElementRepository _spawnUnit;
        
        private GridElementRepositoryCollection _elementCollection;
        private MergeRepositoryCollection _mergeCollection;
        private GridColorizeRepositoryCollection _colorizeCollection;

        private GridViewSpawner _viewSpawner;
        private GridInputReader _inputReader;
        private GridViewDrawer _drawer;
        private GridColorizer _colorizer;

        private GridDrawerService _drawerService;
        private GridMergeService _mergeService;
        private GridPointerMoverService _pointerMoverService;
        private CellStateService _cellStateService;
        private CellStateRenderService _cellStateRenderService;
        
        private GridMergeUseCase _gridMergeUseCase;
        private GridRandomPlaceUseCase _randomPlaceUseCase;
        private GridUnitSpawnUseCase _unitSpawnUseCase;
        
        private GridModelFactory _factory = new GridModelFactory();
        private CellPointer _pointer = new CellPointer();
        
        private void Awake()
        {
            _elementCollection = new GridElementRepositoryCollection(_elementRepositoryContainer.Get());
            _mergeCollection = new MergeRepositoryCollection(_mergeResultRepositoryContainer.Get());
            _colorizeCollection = new GridColorizeRepositoryCollection(_colorizeRepositoryContainer.Get());
            
            _viewSpawner = new GridViewSpawner(_layoutGroup, _gridElementView);
            
            IGridModel gridModel = _factory.Create(_gridRepository);
            IGridView gridView = _viewSpawner.SpawnGrid(new Vector2Int(gridModel.Width, gridModel.Height));
            UnitFactory unitFactory = new UnitFactory();

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

        private void Start()
        {
            SpawnUnit();
            Invoke(nameof(Start), _autoSpawnDelay);
        }
    }
}