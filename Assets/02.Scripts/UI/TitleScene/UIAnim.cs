using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAnim : MonoBehaviour
{
    public List<CanvasGroup> items;
    public float groupMoveOffset = 200f;
    public float groupMoveTime = 0.4f;

    public float itemFadeTime = 0.25f;
    public float itemDelay = 0.05f;

    Vector3 originPos;

    void Start()
    {
        originPos = transform.localPosition;
        transform.localPosition = originPos - Vector3.right * groupMoveOffset;

        foreach (var cg in items)
            cg.alpha = 0;

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        StartCoroutine(MoveGroup());

        for (int i = 0; i < items.Count; i++)
        {
            StartCoroutine(FadeIn(items[i]));
            yield return new WaitForSecondsRealtime(itemDelay);
        }
    }

    IEnumerator MoveGroup()
    {
        float t = 0;
        Vector3 start = transform.localPosition;
        Vector3 end = originPos;

        while (t < groupMoveTime)
        {
            t += Time.unscaledDeltaTime;
            float ratio = t / groupMoveTime;
            ratio = ratio * ratio * (3f - 2f * ratio);

            transform.localPosition = Vector3.Lerp(start, end, ratio);
            yield return null;
        }

        transform.localPosition = end;
    }

    IEnumerator FadeIn(CanvasGroup cg)
    {
        float t = 0;

        while (t < itemFadeTime)
        {
            t += Time.unscaledDeltaTime;
            cg.alpha = t / itemFadeTime;
            yield return null;
        }

        cg.alpha = 1;
    }
}
