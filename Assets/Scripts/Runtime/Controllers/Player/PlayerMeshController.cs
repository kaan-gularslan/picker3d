using DG.Tweening;
using Runtime.Data.ValueObjects.PlayerData;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

namespace Runtime.Controllers.Player
{
    public class PlayerMeshController
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private TextMeshPro _scaleText;
        [SerializeField] private ParticleSystem _confetti;
        [ShowInInspector] private PlayerMeshData _data;

        internal void SetData(PlayerMeshData data)
        {
            _data = data;
        }

        internal void ScaleUpPlayer(PlayerMeshData data)
        {
            _renderer.gameObject.transform.DOScaleX(_data.ScaleCounter,1).SetEase(Ease.OutBack);
        }

        internal void ShowUpText()
        {
            _scaleText.DOFade(1, 0).SetEase((Ease.Flash)).OnComplete(() =>
            {
                _scaleText.DOFade(0, .30f).SetDelay((.35f));
                _scaleText.rectTransform.DOAnchorPosY(1f, .65f).SetEase(Ease.Linear);
            });
        }

        internal void PlayConfetti()
        {
            _confetti.Play();


        }

        internal void OnReset()
        {
            _renderer.gameObject.transform.DOScaleX(1, 1).SetEase(Ease.Linear);
        }

    }
}