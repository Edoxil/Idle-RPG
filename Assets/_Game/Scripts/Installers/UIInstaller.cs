using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationSwitchView _locationsView;
        [SerializeField, Required] private SearchEnemyView _searchEnemyView;

        public override void InstallBindings()
        {
            BindLocationsView();
            BindSearchEnemyView();
        }

        private void BindLocationsView()
        {
            Container.BindInterfacesAndSelfTo<LocationSwitchView>()
                .FromInstance(_locationsView)
                .AsSingle()
                .NonLazy();
        }

        private void BindSearchEnemyView()
        {
            Container.BindInterfacesAndSelfTo<SearchEnemyView>()
                .FromInstance(_searchEnemyView)
                .AsSingle()
                .NonLazy();
        }
    }
}