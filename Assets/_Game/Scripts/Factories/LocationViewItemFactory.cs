using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class LocationViewItemFactory : IFactory<LocationViewItem>
    {
        private LocationsDataProvider _dataProvider;

        [Inject]
        public void Construct(LocationsDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public LocationViewItem Create(Transform parent = null)
        {
            return GameObject.Instantiate(_dataProvider.GetViewItemPrefab(), parent);
        }
    }
}