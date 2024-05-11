using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class DataProvidersInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationsDataProvider _locationsDataProvider;

        public override void InstallBindings()
        {
            Container.Bind<LocationsDataProvider>()
                .FromInstance(_locationsDataProvider)
                .AsSingle()
                .NonLazy();
        }
    }
}