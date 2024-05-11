using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private LocationFactory _locationFactory;

        public override void InstallBindings()
        {
            BindLocationFactory();
        }

        private void BindLocationFactory()
        {
            Container.Bind<IFactory<Location, LocationType>>()
                .FromInstance(_locationFactory)
                .AsSingle()
                .NonLazy();
        }
    }
}