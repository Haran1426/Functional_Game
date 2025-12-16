using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class TitleCutsceneController : MonoBehaviour
{
    [Header("컷씬 부모")]
    public RectTransform cutsceneRoot;

    [Header("컷 이미지들 (순서 중요)")]
    public RawImage[] cuts;

    [Header("컷 연출")]
    public float cutMoveY = 80f;          // 올라오는 거리
    public float cutDuration = 0.8f;      // 컷 하나 나오는 시간 (느리게)
    public float cutDelay = 0.3f;          // 컷 사이 대기 시간

    [Header("부모 이동")]
    public float rootMoveY = 380f;
    public float rootMoveDuration = 1.5f; // 부모 이동 시간 (느리게)

    private Vector2 rootStartPos;
    private Coroutine cutsceneRoutine;

    public Action onCutsceneEnd;

    void Awake()
    {
        rootStartPos = cutsceneRoot.anchoredPosition;
        InitCuts();
    }

    void InitCuts()
    {
        foreach (var cut in cuts)
        {
            cut.gameObject.SetActive(false);
            cut.color = new Color(1, 1, 1, 0);
        }
    }

    // 🔥 외부에서 호출
    public void PlayCutscene()
    {
        gameObject.SetActive(true);

        if (cutsceneRoutine != null)
            StopCoroutine(cutsceneRoutine);

        cutsceneRoot.anchoredPosition = rootStartPos;
        InitCuts();

        cutsceneRoutine = StartCoroutine(PlayCutsceneRoutine());
    }

    IEnumerator PlayCutsceneRoutine()
    {
        // 1 ~ 5 컷
        for (int i = 0; i < 5 && i < cuts.Length; i++)
        {
            yield return ShowCut(cuts[i]);
            yield return new WaitForSecondsRealtime(cutDelay);
        }

        // 부모 이동 (아래 잘린 부분 보여주기)
        yield return cutsceneRoot
            .DOAnchorPosY(rootStartPos.y + rootMoveY, rootMoveDuration)
            .SetEase(Ease.OutCubic)
            .WaitForCompletion();

        yield return new WaitForSecondsRealtime(0.5f); // 연출 여유

        // 6 ~ 끝 컷
        for (int i = 5; i < cuts.Length; i++)
        {
            yield return ShowCut(cuts[i]);
            yield return new WaitForSecondsRealtime(cutDelay);
        }

        // 컷씬 종료
        yield return new WaitForSecondsRealtime(1.0f);
        onCutsceneEnd?.Invoke();
    }

    IEnumerator ShowCut(RawImage cut)
    {
        cut.gameObject.SetActive(true);

        RectTransform rt = cut.rectTransform;
        Vector2 endPos = rt.anchoredPosition;
        rt.anchoredPosition = endPos - new Vector2(0, cutMoveY);

        cut.color = new Color(1, 1, 1, 0);

        Sequence seq = DOTween.Sequence();
        seq.Join(rt.DOAnchorPos(endPos, cutDuration).SetEase(Ease.OutCubic));
        seq.Join(cut.DOFade(1f, cutDuration));

        yield return seq.WaitForCompletion();
    }
}
