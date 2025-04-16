using UnityEngine;
using System.Collections;
using NaughtyAttributes;

public class InterFade : MonoBehaviour
{
    [SerializeField] private CanvasGroup _FadeCanvasGroup;
    [SerializeField] private float _fadeDuration;
    
    private bool _isOpen = false;

    [Button]
    private void ToggleUI()
    {
        _isOpen = !_isOpen;
        
        _FadeCanvasGroup.Fade(_isOpen, _fadeDuration);
        // StartCoroutine(Faded(_isOpen));
    }

    // IEnumerator Faded(bool isOpen)
    // {
    //     float alpha = isOpen ? 0f : 1f;
    //
    //     if (isOpen)
    //     {
    //         while (alpha < 1f)
    //         {
    //             alpha += _fadeSpeed * Time.deltaTime;
    //             _FadeCanvasGroup.alpha = alpha;
    //             yield return null;
    //         }
    //     }
    //     else
    //     {
    //         while (alpha > 0)
    //         {
    //             alpha -= _fadeSpeed * Time.deltaTime;
    //             _FadeCanvasGroup.alpha = alpha;
    //             yield return null;
    //         }
    //     }
    //
    //     yield return new WaitForSeconds(0.5f);
    //     Debug.Log("Faded");
    // }
}
