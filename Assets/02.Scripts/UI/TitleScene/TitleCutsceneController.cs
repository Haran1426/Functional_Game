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
    public float cutMoveY = 80f;
    public float cutDuration = 0.8f;
    public float cutDelay = 0.3f;

    [Header("부모 이동")]
    public float rootMoveY = 380f;
    public float rootMoveDuration = 1.5f;

    [Header("스킵 UI")]
    public GameObject skipUI;   // "Press Enter to Skip"

    private Vector2 rootStartPos;
    private Coroutine cutsceneRoutine;

    private bool isPlaying = false;
    private bool skipReady = false;   // 엔터 1번 눌렀는지

    public Action onCutsceneEnd;

    void Awake()
    {
        rootStartPos = cutsceneRoot.anchoredPosition;
        InitCuts();

        if (skipUI != null)
            skipUI.SetActive(false);
    }

    void Update()
    {
        if (!isPlaying) return;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 첫 번째 엔터 → 스킵 UI 표시
            if (!skipReady)
            {
                skipReady = true;
                if (skipUI != null)
                    skipUI.SetActive(true);
            }
            // 두 번째 엔터 → 컷씬 즉시 종료
            else
            {
                SkipCutscene();
            }
        }
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
        {
            StopCoroutine(cutsceneRoutine);
            cutsceneRoutine = null;
        }

        // 상태 초기화
        isPlaying = true;
        skipReady = false;
        if (skipUI != null)
            skipUI.SetActive(false);

        // DOTween 정리
        cutsceneRoot.DOKill(true);
        foreach (var cut in cuts)
            cut.DOKill(true);

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

        // 부모 이동
        yield return cutsceneRoot
            .DOAnchorPosY(rootStartPos.y + rootMoveY, rootMoveDuration)
            .SetEase(Ease.OutCubic)
            .WaitForCompletion();

        yield return new WaitForSecondsRealtime(0.5f);

        // 6 ~ 끝
        for (int i = 5; i < cuts.Length; i++)
        {
            yield return ShowCut(cuts[i]);
            yield return new WaitForSecondsRealtime(cutDelay);
        }

        EndCutscene();
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

    // 🔥 스킵 처리
    void SkipCutscene()
    {
        if (!isPlaying) return;

        // 코루틴 / 트윈 정리
        if (cutsceneRoutine != null)
        {
            StopCoroutine(cutsceneRoutine);
            cutsceneRoutine = null;
        }

        cutsceneRoot.DOKill(true);
        foreach (var cut in cuts)
            cut.DOKill(true);

        EndCutscene();
    }

    void EndCutscene()
    {
        isPlaying = false;
        skipReady = false;

        if (skipUI != null)
            skipUI.SetActive(false);

        onCutsceneEnd?.Invoke();

        gameObject.SetActive(false);
    }
}
