using System;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class SearchEnemySystem : IInitializable, IEnemySearcher
    {
        [SerializeField] private float _defaultSerchingTime = 3f;
        [SerializeField] private float _fastEnemySearchingTime = 1.5f;

        private Player _player;

        private DelayedAction _searchingAction;
        private float _searchingTime;

        public event Action SearchComplete;

        [Inject]
        public SearchEnemySystem(Player player)
        {
            _player = player;
        }

        public void Initialize()
        {
            _searchingTime = _player.IsFastEnemySearchLearned() ? _fastEnemySearchingTime : _defaultSerchingTime;
        }

        public void StartSearching()
        {
            _searchingAction = new DelayedAction(_searchingTime, () => SearchComplete?.Invoke());
            _searchingAction.Execute();
        }
    }
}