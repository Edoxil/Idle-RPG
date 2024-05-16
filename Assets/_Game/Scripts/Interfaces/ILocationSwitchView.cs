using System;

namespace IdleRPG
{
    public interface ILocationSwitchView
    {
        public event Action<LocationType> SwitchLocationRequested;
    }
}