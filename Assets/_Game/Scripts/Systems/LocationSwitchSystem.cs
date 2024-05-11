using AppCore;
using System;
using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class LocationSwitchSystem : MonoBehaviour, IInitializable
    {
        [SerializeField] private LocationType _defaultLocation;
        private IFactory<Location, LocationType> _factory;

        private readonly string _savingKey = "LastVisitedLocation";
        private LocationType _lastVisitedLocation;

        [ShowInInspector, ReadOnly] public Location CurrentLocation { get; private set; }
        
        public event Action<Location> LocationSwitched;

        [Inject]
        public void Construct(IFactory<Location, LocationType> factory)
        {
            _factory = factory;
        }

        public void Initialize()
        {
            Load();
            SwitchLocation(_lastVisitedLocation);
        }
        [Button]
        private void SwitchLocation(LocationType locationType)
        {
            if (CurrentLocation != null)
                Destroy(CurrentLocation.gameObject);

            CurrentLocation = _factory.Create(locationType);
            _lastVisitedLocation = locationType;

            LocationSwitched?.Invoke(CurrentLocation);
            Save();
        }

        private void Save()
        {
            SavingData data = new SavingData() { LastVisitedLocation = _lastVisitedLocation };
            SavingSystem.Save(data, _savingKey);
        }

        private void Load()
        {
            SavingData? data = SavingSystem.Load<SavingData>(_savingKey);

            if (data.HasValue)
                _lastVisitedLocation = data.Value.LastVisitedLocation;
            else
                _lastVisitedLocation = _defaultLocation;
        }


        [System.Serializable]
        private struct SavingData
        {
            public LocationType LastVisitedLocation;
        }
    }
}