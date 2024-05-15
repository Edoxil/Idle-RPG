using TriInspector;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IdleRPG
{
    public class SearchEnemyView : MonoBehaviour
    {
        [SerializeField, Required] private Button _btnStartSearch;
        [SerializeField,Required] private UIAnimation _searchAnimation;

        private SearchEnemySystem _searchEnemySystem;

        [Inject]
        public void Construct(SearchEnemySystem searchEnemySystem)
        {
            _searchEnemySystem = searchEnemySystem;
        }

        private void OnEnable()
        {
            _btnStartSearch.onClick.AddListener(OnStartSearchButtonClick);
            _searchEnemySystem.SearchComplete += OnSearchComplete;
        }

        private void OnDisable()
        {
            _btnStartSearch.onClick.RemoveAllListeners();
            _searchEnemySystem.SearchComplete -= OnSearchComplete;
        }

        private void OnStartSearchButtonClick()
        {
            _searchEnemySystem.StartSearching();
            _btnStartSearch.gameObject.SetActive(false);
            _searchAnimation.Play();
        }

        private void OnSearchComplete()
        {
            _searchAnimation.Stop();
        }
    }
}