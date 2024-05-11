using System;
using Zenject;

namespace IdleRPG
{
    public class PlayerEntryLocationSystem : IInitializable, IDisposable
    {
        private Player _player;
        private LocationSwitchSystem _locationSwitchSystem;

        [Inject]
        public void Construct(Player player, LocationSwitchSystem locationSwitchSystem)
        {
            _player = player;
            _locationSwitchSystem = locationSwitchSystem;
        }

        public void Initialize()
        {
            _locationSwitchSystem.LocationSwitched += OnLocationSwitched;
            OnLocationSwitched(_locationSwitchSystem.CurrentLocation);
        }

        public void Dispose()
        {
            _locationSwitchSystem.LocationSwitched -= OnLocationSwitched;
        }

        private void OnLocationSwitched(Location location)
        {
            _player.ResetAnimations();
            _player.transform.position = location.PlayerSpawnPoint.position;
        }

    }
}