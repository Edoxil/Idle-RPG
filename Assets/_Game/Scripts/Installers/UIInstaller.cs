using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class UIInstaller : MonoInstaller
    {
        [SerializeField, Required] private LocationsView _locationsView;

        public override void InstallBindings()
        {
            BindLocationsView();
        }

        private void BindLocationsView()
        {
            Container.BindInterfacesAndSelfTo<LocationsView>()
                .FromInstance(_locationsView)
                .AsSingle()
                .NonLazy();
        }
    }
}