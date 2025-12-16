using UnityEngine;

public class PlayerMove_NA : MonoBehaviour
{
    public float speed = 7f;
    private int direction = 1;
    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!GameManager_NA.Instance.isGameStart)
            return;

        if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
            sr.flipX = true;   // 왼쪽 바라봄
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
            sr.flipX = false;  // 오른쪽 바라봄
        }

        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }
}
