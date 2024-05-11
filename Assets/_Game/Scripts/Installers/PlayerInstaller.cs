using TriInspector;
using UnityEngine;
using Zenject;

namespace IdleRPG
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField,Required] private Player _prefab;

        private Player _player;

        public override void InstallBindings()
        {
            _player = Instantiate(_prefab, transform);

            Container.BindInterfacesAndSelfTo<Player>()
                .FromInstance(_player)
                .AsSingle()
                .NonLazy();
        }
    }
}