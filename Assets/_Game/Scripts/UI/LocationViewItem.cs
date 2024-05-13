using System;
using TriInspector;
using UnityEngine;
using UnityEngine.UI;

namespace IdleRPG
{
    public class LocationViewItem : MonoBehaviour
    {
        [SerializeField, Required] private Button _button;
        [SerializeField, Required] private Image _icon;

        [ShowInInspector, ReadOnly] public LocationType LocationType { get; private set; }

        public event Action<LocationType> SwitchLocationButtonClick;

        public void Initialize(LocationType locationType, Sprite icon)
        {
            LocationType = locationType;
            _icon.sprite = icon;
        }

        public void SetInteractableStatus(bool interactable)
        {
            _button.interactable = interactable;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void OnButtonClick()
        {
            SwitchLocationButtonClick?.Invoke(LocationType);
        }

    }
}