using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class TweenScale : MonoBehaviour
    {
        [SerializeField] private Vector3 originScale;
        [SerializeField] private Vector3 scaleTo;
        [SerializeField] private float duration = 2f;
        [SerializeField] private float multiplyScale = 2f;

        private void Start()
        {
            originScale = transform.localScale;
            scaleTo = originScale * multiplyScale;

            transform.DOScale(scaleTo, duration).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo).SetUpdate(true);
        }
        
        void OnDestroy()
        {
            DOTween.Kill(transform);
            DOTween.Kill(gameObject);
            foreach (Transform child in transform)
            {
                DOTween.Kill(child);
            }
        }
    }
}