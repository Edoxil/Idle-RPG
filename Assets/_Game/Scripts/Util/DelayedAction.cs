using AppCore;
using DG.Tweening;
using System;

namespace IdleRPG
{
    public class DelayedAction
    {
        private Action _action;
        private float _delay;
        private Tween _tween;

        public float Progress { get; private set; }
        public bool IsPaused { get; private set; }

        public DelayedAction(float delay, Action action)
        {
            if (delay < 0f)
                throw new ArgumentOutOfRangeException("Delay cannot be less than zero!");

            _delay = delay;
            _action = action;
        }

        public void Execute()
        {
            _tween?.KillIfActiveOrPlaying();

            _tween = DOVirtual.DelayedCall(_delay, () => _action?.Invoke(), false)
                .OnUpdate(() => Progress = _tween.ElapsedPercentage(false));

            IsPaused = false;
        }

        public void Interrupt()
        {
            IsPaused = true;
            _tween?.KillIfActiveOrPlaying();
        }

        public void Pause()
        {
            IsPaused = true;
            _tween?.Pause();
        }

        public void UnPause()
        {
            IsPaused = false;
            _tween?.Play();
        }

        public void Restart()
        {
            Execute();
        }
    }
}