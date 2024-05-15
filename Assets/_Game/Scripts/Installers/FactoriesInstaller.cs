using Zenject;

namespace IdleRPG
{
    public sealed class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLocationFactory();
            BindLocationViewItemFactory();
            BindEnemiesFactory();
        }

        private void BindLocationFactory()
        {
            Container.Bind<IFactory<Location, LocationType>>()
                .To<LocationFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindEnemiesFactory()
        {
            Container.Bind<IFactory<Enemy, EnemyType>>()
                .To<EnemiesFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }

        private void BindLocationViewItemFactory()
        {
            Container.Bind<IFactory<LocationViewItem>>()
                .To<LocationViewItemFactory>()
                .FromNew()
                .AsSingle()
                .NonLazy();
        }
    }
}