using UnityEngine;

public class TrashHit : MonoBehaviour
{
    public int point;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player"))
        {
            HANUIManager.instance.AddScore(point);
            TrashPool.instance.ReturnTrash(gameObject);
        }
    }

    void Update()
    {

    }
}
