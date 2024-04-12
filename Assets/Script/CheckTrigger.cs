using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private const string COIN = "Coin";
    private const string WALL = "Wall";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(COIN))
        {
            GameManager.Instance.AddScore(); // Calls the public method
            Destroy(other.gameObject);
        }

        if (other.CompareTag(WALL))
        {
            GameManager.Instance.GameOver(); // Calls the public method
        }
    }
}
