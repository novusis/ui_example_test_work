using UnityEngine;

namespace Tools
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaPanel : MonoBehaviour
    {
        private RectTransform rectTransform;
        private Rect currentSafeArea;
        private ScreenOrientation currentOrientation;

        private void Start()
        {
            rectTransform = GetComponent<RectTransform>();
            currentOrientation = Screen.orientation;
            currentSafeArea = Screen.safeArea;

            ApplySafeArea();
        }

        private void Update()
        {
            if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
            {
                currentOrientation = Screen.orientation;
                currentSafeArea = Screen.safeArea;

                ApplySafeArea();
            }
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;

            Vector2 anchorMin = safeArea.position;
            Vector2 anchorMax = safeArea.position + safeArea.size;

            anchorMin.x /= Screen.width;
            anchorMin.y /= Screen.height;
            anchorMax.x /= Screen.width;
            anchorMax.y /= Screen.height;

            rectTransform.anchorMin = anchorMin;
            rectTransform.anchorMax = anchorMax;
        }
    }
}