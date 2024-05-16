using System;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class SearchEnemySystem : IInitializable, IEnemySearchSystem, IDisposable
    {
        [SerializeField] private float _defaultSerchingTime = 3f;
        [SerializeField] private float _fastEnemySearchingTime = 1.5f;

        private Player _player;

        private DelayedAction _searchingAction;
        private float _searchingTime;
        private ILocationSwitchSystem _locationSwitcher;
        private ISearchEnemyView _view;
        private ICombatSystem _combatSystem;

        public event Action SearchCompleted;

        [Inject]
        public SearchEnemySystem(Player player, ILocationSwitchSystem locationSwitcher,
            ISearchEnemyView view, ICombatSystem combatSystem)
        {
            _player = player;
            _locationSwitcher = locationSwitcher;
            _view = view;
            _combatSystem = combatSystem;
        }

        public void Initialize()
        {
            _locationSwitcher.LocationSwitched += OnLocationSwitched;
            _view.StartSearchRequested += StartSearching;
            _combatSystem.CombatInterrupted += OnCombatInterrupted;

            _searchingTime = _player.IsFastEnemySearchLearned() ? _fastEnemySearchingTime : _defaultSerchingTime;
            _view.ShowSearchInitiationElements();
        }

        public void Dispose()
        {
            _locationSwitcher.LocationSwitched -= OnLocationSwitched;
            _view.StartSearchRequested -= StartSearching;
            _combatSystem.CombatInterrupted -= OnCombatInterrupted;
        }

        private void StartSearching()
        {
            _view.HideSearchInitiationElements();
            _view.ShowSearchAnimationElements();

            _searchingAction = new DelayedAction(_searchingTime, CompleteSearching);
            _searchingAction.Execute();
        }

        private void CompleteSearching()
        {
            _view.HideSearchAnimationElements();
            SearchCompleted?.Invoke();
        }

        private void OnLocationSwitched(Location obj)
        {
            _view.HideSearchAnimationElements();
            _searchingAction?.Interrupt();
            _view.ShowSearchInitiationElements();
        }

        private void OnCombatInterrupted()
        {
            _view.ShowSearchInitiationElements();
        }
    }
}