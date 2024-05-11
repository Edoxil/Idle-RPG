using UnityEngine;

namespace IdleRPG
{
    public interface IFactory<T> where T : Object
    {
        public T Create(Transform parent = null);
    }

    public interface IFactory<T, Key> where Key : System.Enum where T : Object
    {
        public T Create(Key key, Transform parent = null);
    }
}