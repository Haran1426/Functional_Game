using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAnim : MonoBehaviour
{
    public List<CanvasGroup> items;
    public float fadeTime = 0.3f;
    public float delay = 0.1f;

    void Start()
    {
        foreach (var cg in items)
            cg.alpha = 0;

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        foreach (var cg in items)
        {
            yield return StartCoroutine(FadeIn(cg));
            yield return new WaitForSeconds(delay);
        }
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0;
        cg.alpha = 0;

        while (t < fadeTime)
        {
            t += Time.deltaTime;
            cg.alpha = t / fadeTime;
            yield return null;
        }

        cg.alpha = 1;
    }
}