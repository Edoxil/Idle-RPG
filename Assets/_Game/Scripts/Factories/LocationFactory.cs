using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public sealed class LocationFactory : IFactory<Location, LocationType>
    {
        private LocationsDataProvider _locationsDataProvider;

        [Inject]
        public void Construct(LocationsDataProvider locationsDataProvider)
        {
            _locationsDataProvider = locationsDataProvider;
        }

        public Location Create(LocationType locationType, Transform parent)
        {
            Location location = _locationsDataProvider.GetPrefab(locationType);
            return GameObject.Instantiate(location, parent);
        }
    }
}