using UnityEngine;

public class Flowerpot : MonoBehaviour
{
    public int stage = 0;
    public int maxStage = 3;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        UpdateView();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Grow();
        }
    }

    void Grow()
    {
        if (stage >= maxStage) return;

        stage++;
        UpdateView();
    }

    void UpdateView()
    {
        float scale = 2f + stage * 0.3f;
        transform.localScale = Vector3.one * scale; 
    }
}
