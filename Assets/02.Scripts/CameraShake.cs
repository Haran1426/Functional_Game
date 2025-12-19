using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    Vector3 originPos;

    void Awake()
    {
        originPos = transform.localPosition;
    }

    public void Shake(float duration = 0.15f, float strength = 0.15f)
    {
        StopAllCoroutines();
        StartCoroutine(ShakeRoutine(duration, strength));
    }

    IEnumerator ShakeRoutine(float duration, float strength)
    {
        float t = 0;

        while (t < duration)
        {
            t += Time.unscaledDeltaTime;

            Vector2 offset = Random.insideUnitCircle * strength;
            transform.localPosition = originPos + (Vector3)offset;

            yield return null;
        }

        transform.localPosition = originPos;
    }
}
