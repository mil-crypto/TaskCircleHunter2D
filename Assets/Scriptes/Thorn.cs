using UnityEngine;

public class Thorn : MonoBehaviour
{
    public static bool isPlayerDead;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerDead = true;
            Destroy(collision.gameObject);
        }
    }
}
