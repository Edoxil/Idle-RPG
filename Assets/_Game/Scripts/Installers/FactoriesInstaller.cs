using Zenject;

namespace IdleRPG
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLocationFactory();
            BindLocationBiewItemFactory();
        }

        private void BindLocationFactory()
        {
            Container.Bind<IFactory<Location, LocationType>>()
                .To<LocationFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindLocationBiewItemFactory()
        {
            Container.Bind<IFactory<LocationViewItem>>()
                .To<LocationViewItemFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}