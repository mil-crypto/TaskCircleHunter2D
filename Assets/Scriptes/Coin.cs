using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int coins;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coins++;
            Debug.Log(coins);
            Destroy(gameObject);
        }
    }
}
