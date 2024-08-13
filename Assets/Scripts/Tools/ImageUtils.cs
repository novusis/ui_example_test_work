using UnityEngine;
using UnityEngine.UI;

namespace Tools
{
    public static class ImageUtils
    {
        public static void ResizeByParent(this Image image, bool expand)
        {
            if (image.sprite == null)
            {
                image.rectTransform.anchorMin = Vector2.zero;
                image.rectTransform.anchorMax = Vector2.one;
                image.rectTransform.offsetMin = Vector2.zero;
                image.rectTransform.offsetMax = Vector2.zero;
                return;
            }

            image.rectTransform.anchorMax = Vector2.one / 2f;
            image.rectTransform.anchorMin = Vector2.one / 2f;
            image.SetNativeSize();
            var deltaSize = image.transform.parent as RectTransform;
            var parentSize = new Vector2(deltaSize.rect.width, deltaSize.rect.height);
            var imageSize = image.rectTransform.sizeDelta;
            if (parentSize.x / parentSize.y > imageSize.x / imageSize.y)
            {
                imageSize *= expand ? parentSize.x / imageSize.x : parentSize.y / imageSize.y;
            }
            else
            {
                imageSize *= expand ? parentSize.y / imageSize.y : parentSize.x / imageSize.x;
            }

            image.rectTransform.sizeDelta = imageSize;
        }
    }
}