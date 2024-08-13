using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    [RequireComponent(typeof(RectTransform))]
    public class SwitchImages : MonoBehaviour
    {
        [SerializeField] private Image mainImage;
        [SerializeField] private Image animateImage;
        [SerializeField] private float animateDuration = 0.4f;
        private RectTransform _rectTransform;

        private void Start()
        {
            _rectTransform = transform as RectTransform;
        }

        public void SetImage(Sprite sprite)
        {
            if (mainImage.sprite)
            {
                animateImage.sprite = mainImage.sprite;
                animateImage.gameObject.SetActive(true);
                animateImage.ResizeByParent(true);
                animateImage.color = new Color(animateImage.color.r, animateImage.color.g, animateImage.color.b, 1f);
                animateImage.DOFade(0, animateDuration);
            }
            else
            {
                animateImage.gameObject.SetActive(false);
            }

            mainImage.sprite = sprite;
            mainImage.ResizeByParent(true);
        }

        private void Update()
        {
            if (_rectTransform.hasChanged)
            {
                _rectTransform.hasChanged = false;
                if (mainImage.sprite)
                    mainImage.ResizeByParent(true);

                if (animateImage.sprite)
                    animateImage.ResizeByParent(true);
            }
        }
    }
}