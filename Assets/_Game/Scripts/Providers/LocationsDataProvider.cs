using System.Collections.Generic;
using System.Linq;
using TriInspector;
using UnityEngine;

namespace IdleRPG
{
    [CreateAssetMenu(fileName = "LocationsDataProvider", menuName = "Providers/LocationsDataProvider", order = 1)]
    public class LocationsDataProvider : ScriptableObject
    {
        [SerializeField] private List<Location> _allLocations;
        [SerializeField,Required] private LocationViewItem _viewItemPrefab;

        public Location GetPrefab(LocationType locationType)
        {
            return _allLocations.First(l => l.LocationType == locationType);
        }

        public Sprite GetIcon(LocationType locationType)
        {
            return _allLocations.First(l => l.LocationType == locationType).Icon;
        }

        public LocationViewItem GetViewItemPrefab()
        {
            return _viewItemPrefab;
        }

        public IEnumerable<LocationType> AllLocationsTypes()
        {
            return _allLocations.Select(location => location.LocationType);
        }
    }

}