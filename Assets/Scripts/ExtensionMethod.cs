using PrimeTween;
using UnityEngine;

public static class ExtensionMethod
{
    public static void Fade(this CanvasGroup canvasGroup, bool isShow, float fadeDuration = 0.5f)
    {
        float targetAlpha = isShow ? 1f : 0f;

        if (Mathf.Approximately(canvasGroup.alpha, targetAlpha))
        {
            canvasGroup.SetCanvasGroupInteraction(isShow);
                return;
        }

        canvasGroup.SetCanvasGroupInteraction(isShow);
        Tween.Alpha(canvasGroup, targetAlpha, fadeDuration);
    }

    public static void Hide(this CanvasGroup canvasGroup)
    {
        canvasGroup.alpha = 0f;
        canvasGroup.SetCanvasGroupInteraction(false);
    }
    public static void SetCanvasGroupInteraction(this CanvasGroup canvasGroup, bool isEnable)
    {
        canvasGroup.blocksRaycasts = isEnable;
        canvasGroup.interactable = isEnable;
    }
}
