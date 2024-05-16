using System;

namespace IdleRPG
{
    public interface ISearchEnemyView
    {
        public event Action StartSearchRequested;

        public void ShowSearchInitiationElements();
        public void HideSearchInitiationElements();

        public void ShowSearchAnimationElements();
        public void HideSearchAnimationElements();

    }
}