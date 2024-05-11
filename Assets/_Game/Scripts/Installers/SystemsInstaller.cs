using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationSwitchSystem _locationSwitchSystem;

        private PlayerEntryLocationSystem _playerEntryLocationSystem;

        public override void InstallBindings()
        {
            BindLocationSwitchSystem();
            BindPlayerEntryLocationSystem();
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
            _playerEntryLocationSystem = new PlayerEntryLocationSystem();

            Container.BindInterfacesTo<PlayerEntryLocationSystem>()
                .AsSingle()
                .NonLazy();
        }

    }
}