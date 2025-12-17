using UnityEngine;

public class TrashHit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            HANUIManager.instance.AddScore(1);
            Destroy(gameObject);
        }
    }
}
