using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TMP_Text currentText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button restartButton;

    public Camera mainCam;
    

    private int randomIndex;
    [SerializeField] private Color[] colorToChange;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        randomIndex = Random.Range(0, colorToChange.Length);
        ChangeColor();
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString(); // Set score text to the initial score value
        GameOverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

   
    }

   

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        randomIndex = Random.Range(0, colorToChange.Length);
        ApplyColor();
    }
    public void GameOver()
    {

       
        // Play game over sound
        FindObjectOfType<AudioManager>().Play("GameOver");

        // Update high score if current score is higher
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        // Save current score and high score to PlayerPrefs
        PlayerPrefs.SetInt("Score", score);

        // Update UI text
        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        // Show game over panel
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }


    private void RestartLevel()
    {
        
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1;
    }

    void ApplyColor()
    {
        if (score >= 2)
        {
            ChangeColor();
        }
        else if (score == 5)
        {
            ChangeColor();
        }
    }

    public void ChangeColor()
    {
        mainCam.backgroundColor = colorToChange[randomIndex];
       
    }
}
