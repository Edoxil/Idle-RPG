using AppCore;
using DG.Tweening;
using TriInspector;
using UnityEngine;

namespace IdleRPG
{
    public class SearchAnimation : UIAnimation
    {
        [SerializeField, Required] private RectTransform _animatedTransform;

        [SerializeField] private float _startAngle = 0f;
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private float _speed = 0.1f;

        [SerializeField] private float _scaleDur = 0.35f;

        private float _angle;
        private Tween _tween;

        private float _xPos = 0f;
        private float _yPos = 0f;

        private Vector2 _calculatedPos;

        public override bool IsPlaying { get; protected set; }

        private void Start()
        {
            _animatedTransform.gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            if (IsPlaying == false)
                return;

            _angle += _speed * Time.deltaTime;

            _xPos = Mathf.Cos(_angle) * _radius;
            _yPos = Mathf.Sin(_angle) * _radius;
            _calculatedPos = new Vector2(_xPos, _yPos);

            _animatedTransform.anchoredPosition = _calculatedPos;
        }
       
        public override void Play()
        {
            _animatedTransform.gameObject.SetActive(true);

            _tween.KillIfActiveOrPlaying();
            _tween = _animatedTransform.DOScale(1f, _scaleDur).ChangeStartValue(Vector3.zero);

            _angle = _startAngle;
            IsPlaying = true;
        }

        public override void Stop()
        {
            _tween.KillIfActiveOrPlaying();
            _tween = _animatedTransform.DOScale(0f, _scaleDur)
                .OnComplete(() => _animatedTransform.gameObject.SetActive(false));

            IsPlaying = false;
        }
    }
}