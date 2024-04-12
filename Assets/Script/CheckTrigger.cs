using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private const string COIN = "Coin";
    private const string WALL = "Wall";

    private GameManager gameManager;

    // Method to set the GameManager instance
    public void SetGameManager(GameManager manager)
    {
        gameManager = manager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(COIN))
        {
            if (gameManager != null)
            {
                gameManager.AddScore(); // Calls the public method
            }
            Destroy(other.gameObject);
        }

        if (other.CompareTag(WALL))
        {
            if (gameManager != null)
            {
                gameManager.GameOver(); // Calls the public method
            }
        }
    }
}
