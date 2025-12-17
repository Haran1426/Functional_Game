using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAnim : MonoBehaviour
{
    public List<CanvasGroup> items;
    public float fadeTime = 0.3f;
    public float startDelay = 0.1f;

    void Start()
    {
        foreach (var cg in items)
            cg.alpha = 0;

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        for (int i = 0; i < items.Count; i++)
        {
            StartCoroutine(FadeIn(items[i]));
            yield return new WaitForSecondsRealtime(startDelay);
        }
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0;
        cg.alpha = 0;

        while (t < fadeTime)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = t / fadeTime;
            yield return null;
        }

        cg.alpha = 1;
    }
}
