using UnityEngine;

public class CheckTrigger : MonoBehaviour
{
    private const string COIN = "Coin";
    private const string WALL = "Wall";

    private AudioManager audioManager; // Declare AudioManager variable

    private void Start()
    {
        audioManager = AudioManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(COIN))
        {
            if (audioManager != null)
            {
                audioManager.PlaySound(SoundName.Coin); // Play Coin sound
            }
            GameManager.Instance.AddScore(); // Calls the AddScore method
            Destroy(other.gameObject);
        }

        if (other.CompareTag(WALL))
        {
            if (audioManager != null)
            {
                audioManager.PlaySound(SoundName.GameOver); // Play GameOver sound
            }
            GameManager.Instance.GameOver(); // Calls the GameOver method
        }
    }
}

