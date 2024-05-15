using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class DataProvidersInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationsDataProvider _locationsDataProvider;
        [SerializeField, Required] private EnemiesDataProvider _enemiesDataProvider;

        public override void InstallBindings()
        {
            BindLocationDataProvider();
            BindEnemiesDataProvider();
        }

        private void BindLocationDataProvider()
        {
            Container.Bind<LocationsDataProvider>()
                .FromInstance(_locationsDataProvider)
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemiesDataProvider()
        {
            Container.Bind<EnemiesDataProvider>()
                .FromInstance(_enemiesDataProvider)
                .AsSingle()
                .NonLazy();
        }
    }
}