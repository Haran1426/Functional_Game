using System.Collections;
using UnityEngine;

public class ScalePopUp_SIM : MonoBehaviour
{
    public float startScale = 0.8f;   // 등장할 때 시작 크기
    public float endScale = 1f;       // 최종 크기 (이미지마다 다르게 설정)
    public float duration = 0.09f;

    void OnEnable()
    {
        StartCoroutine(PopUp());
    }

    IEnumerator PopUp()
    {
        transform.localScale = Vector3.one * startScale;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float normalized = t / duration;

            // 부드러운 확대(SmoothStep)
            float eased = Mathf.SmoothStep(0f, 1f, normalized);

            transform.localScale =
                Vector3.Lerp(Vector3.one * startScale, Vector3.one * endScale, eased);

            yield return null;
        }

        transform.localScale = Vector3.one * endScale;
    }
}
