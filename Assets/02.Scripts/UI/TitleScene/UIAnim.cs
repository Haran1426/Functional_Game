using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UIAnim : MonoBehaviour
{
    public List<CanvasGroup> items;

    public float groupOffset = 220f;
    public float moveTime = 0.35f;
    public float overshoot = 20f;

    public float itemFadeTime = 0.25f;
    public float itemDelay = 0.04f;
    public float itemShake = 10f;

    Vector3 originPos;

    void Start()
    {
        originPos = transform.localPosition;
        transform.localPosition = originPos - Vector3.right * groupOffset;

        foreach (var cg in items)
        {
            cg.alpha = 0;
            cg.transform.localPosition -= Vector3.right * itemShake;
        }

        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        StartCoroutine(MoveGroup());

        for (int i = 0; i < items.Count; i++)
        {
            StartCoroutine(ShowItem(items[i], i));
            yield return new WaitForSecondsRealtime(itemDelay);
        }
    }

    IEnumerator MoveGroup()
    {
        float t = 0;

        Vector3 start = transform.localPosition;
        Vector3 overshootPos = originPos + Vector3.right * overshoot;
        Vector3 end = originPos;

        while (t < moveTime)
        {
            t += Time.unscaledDeltaTime;
            float r = t / moveTime;

            float ease = r * r * (3f - 2f * r);

            if (r < 0.85f)
                transform.localPosition = Vector3.Lerp(start, overshootPos, ease);
            else
                transform.localPosition = Vector3.Lerp(overshootPos, end, (r - 0.85f) / 0.15f);

            yield return null;
        }

        transform.localPosition = end;
    }

    IEnumerator ShowItem(CanvasGroup cg, int index)
    {
        float t = 0;

        Vector3 startPos = cg.transform.localPosition;
        Vector3 endPos = startPos + Vector3.right * itemShake;

        while (t < itemFadeTime)
        {
            t += Time.unscaledDeltaTime;
            float r = t / itemFadeTime;

            cg.alpha = r;
            cg.transform.localPosition = Vector3.Lerp(startPos, endPos, r);

            yield return null;
        }

        cg.alpha = 1;
        cg.transform.localPosition = endPos;
    }
}
