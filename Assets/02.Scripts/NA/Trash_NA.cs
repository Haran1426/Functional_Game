using DG.Tweening.Core.Easing;
using UnityEngine;

public class Trash_NA : MonoBehaviour
{
    public float fallSpeed = 3f;

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            GameManager_NA.Instance.TakeDamage();
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Player"))
        {
            // 점수 처리
            GameManager_NA.Instance.AddScore();
            Destroy(gameObject);
        }
    }
}
