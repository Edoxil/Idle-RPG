using System;

namespace IdleRPG
{
    public interface ILocationSwitcher
    {
        public Location CurrentLocation { get; }
        public event Action<Location> LocationSwitched;
    }
}