using System;
using System.Collections.Generic;
using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class LocationsView : MonoBehaviour, IInitializable
    {
        [SerializeField, Required] private RectTransform _contentParent;

        private IFactory<LocationViewItem> _factory;
        private LocationsDataProvider _dataProvider;

        private List<LocationViewItem> _allItems;

        public event Action<LocationType> SwitchLocationRequested;

        [Inject]
        public void Construct(IFactory<LocationViewItem> factory, LocationsDataProvider locationsDataProvider)
        {
            _allItems = new List<LocationViewItem>();
            _factory = factory;
            _dataProvider = locationsDataProvider;
        }

        public void Initialize()
        {
            CreateItems();
        }

        private void OnDestroy()
        {
            DestroyItems();
        }

        private void DestroyItems()
        {
            foreach (var item in _allItems)
            {
                if (item != null)
                    item.SwitchLocationButtonClick -= OnItemClicked;

                if (item.gameObject != null)
                    Destroy(item.gameObject);
            }
            _allItems?.Clear();
        }

        private void CreateItems()
        {
            foreach (var locType in _dataProvider.AllLocationsTypes())
            {
                LocationViewItem item = _factory.Create(_contentParent);
                item.SwitchLocationButtonClick += OnItemClicked;
                Sprite icon = _dataProvider.GetIcon(locType);
                item.Initialize(locType, icon);

                _allItems.Add(item);
            }
        }

        private void OnItemClicked(LocationType locType)
        {
            SwitchLocationRequested?.Invoke(locType);
        }

    }
}