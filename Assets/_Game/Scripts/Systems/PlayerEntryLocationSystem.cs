using System;
using Zenject;

namespace IdleRPG
{
    public class PlayerEntryLocationSystem : IInitializable, IDisposable
    {
        private Player _player;
        private ILocationSwitchSystem _locationSwitcher;

        [Inject]
        public void Construct(Player player, ILocationSwitchSystem locataionSwitcher)
        {
            _player = player;
            _locationSwitcher = locataionSwitcher;
        }

        public void Initialize()
        {
            _locationSwitcher.LocationSwitched += OnLocationSwitched;
            OnLocationSwitched(_locationSwitcher.CurrentLocation);
        }

        public void Dispose()
        {
            _locationSwitcher.LocationSwitched -= OnLocationSwitched;
        }

        private void OnLocationSwitched(Location location)
        {
            _player.EnterLocation();
            _player.transform.position = location.PlayerSpawnPoint.position;
        }

    }
}