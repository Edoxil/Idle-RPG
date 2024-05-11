using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public sealed class LocationFactory : MonoBehaviour, IFactory<Location, LocationType>
    {
        private LocationsDataProvider _locationsDataProvider;

        [Inject]
        public void Construct(LocationsDataProvider locationsDataProvider)
        {
            _locationsDataProvider = locationsDataProvider;
        }

        public Location Create(LocationType locationType, Transform parent = null)
        {
            Location location = _locationsDataProvider.GetPrefab(locationType);
            return Instantiate(location, parent != null ? parent : transform);
        }
    }
}