using System;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace IdleRPG
{
    public class SearchEnemyView : MonoBehaviour, ISearchEnemyView
    {
        [SerializeField, Required] private Button _btnStartSearch;
        [SerializeField, Required] private UIAnimation _searchAnimation;

        public event Action StartSearchRequested;

        private void OnEnable()
        {
            _btnStartSearch.onClick.AddListener(OnStartSearchButtonClick);
        }

        private void OnDisable()
        {
            _btnStartSearch.onClick.RemoveAllListeners();
        }

        private void OnStartSearchButtonClick()
        {
            StartSearchRequested?.Invoke();
        }

        public void ShowSearchInitiationElements()
        {
            _btnStartSearch.gameObject.SetActive(true);
        }

        public void HideSearchInitiationElements()
        {
            _btnStartSearch.gameObject.SetActive(false);
        }

        public void ShowSearchAnimationElements()
        {
            _searchAnimation.Play();
        }

        public void HideSearchAnimationElements()
        {
            _searchAnimation.Stop();
        }
    }
}