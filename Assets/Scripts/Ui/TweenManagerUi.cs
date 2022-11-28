using DG.Tweening;
using UnityEngine;

namespace Ui
{
    public class TweenManagerUi : MonoBehaviour
    {
        [SerializeField] private RectTransform[] scaleTransforms;
        [SerializeField] private RectTransform[] upYTransforms;
        [SerializeField] private RectTransform[] downYTransforms;
        [SerializeField] private float revealDuration=1f;

        private void OnEnable()
        {
            foreach (RectTransform scaleTransform in scaleTransforms)
            {
                scaleTransform.DOScale(Vector3.zero, revealDuration).From().SetUpdate(true);
            }
        
            foreach (RectTransform upYTransform in upYTransforms)
            {
                upYTransform.DOAnchorPosY(500f, revealDuration).From().SetUpdate(true);
            }
        
            foreach (RectTransform downYTransform in downYTransforms)
            {
                downYTransform.DOAnchorPosY(-500f, revealDuration).From().SetUpdate(true);
            }
        }

        public void OnClickTween(RectTransform rectTransform)
        {
            rectTransform.DOScale(rectTransform.localScale * 1.25f, revealDuration / 6f).SetLoops(2,LoopType.Yoyo).SetUpdate(true);
        }
    }
}
