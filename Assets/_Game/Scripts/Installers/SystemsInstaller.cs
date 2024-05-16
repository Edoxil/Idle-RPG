using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationSwitchSystem _locationSwitchSystem;

        public override void InstallBindings()
        {
            BindLocationSwitchSystem();
            BindPlayerEntryLocationSystem();
            BindSearchEnemySystem();
            BindEnemySpawnSystem();
            BindCombatSystem();
        }

        private void BindEnemySpawnSystem()
        {
            Container.BindInterfacesAndSelfTo<EnemySpawnSystem>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindSearchEnemySystem()
        {
            Container.BindInterfacesAndSelfTo<SearchEnemySystem>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindLocationSwitchSystem()
        {
            Container.BindInterfacesAndSelfTo<LocationSwitchSystem>()
                .FromInstance(_locationSwitchSystem)
                .AsSingle()
                .NonLazy();
        }

        private void BindPlayerEntryLocationSystem()
        {
            Container.BindInterfacesTo<PlayerEntryLocationSystem>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindCombatSystem()
        {
            Container.BindInterfacesAndSelfTo<CombatSystem>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

    }
}