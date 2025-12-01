using UnityEngine;

public class TrashHit : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trash"))
        {
            if (player != null)
            {
                player.Damage(damage);
            }
            Destroy(other.gameObject);
        }
    }

    void Update()
    {

    }
}
