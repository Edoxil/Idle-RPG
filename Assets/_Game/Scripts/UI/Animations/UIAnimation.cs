using TriInspector;
using UnityEngine;

namespace IdleRPG
{
    public abstract class UIAnimation : MonoBehaviour
    {
        public abstract bool IsPlaying { get; protected set; }
        [Button]
        public abstract void Play();
        [Button]
        public abstract void Stop();
    }
}