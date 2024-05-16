using System;

namespace IdleRPG
{
    public interface ILocationSwitchSystem
    {
        public Location CurrentLocation { get; }
        public event Action<Location> LocationSwitched;
    }
}