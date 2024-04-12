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
        if (score > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", score);
        }

        PlayerPrefs.SetInt("Score", score);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        
      
        GameOverPanel.SetActive(true);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene("GameScene");
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
