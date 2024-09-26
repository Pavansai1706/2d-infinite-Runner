using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TMP_Text currentText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button restartButton;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString(); // Set score text to the initial score value
        GameOverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt("Score").ToString();
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();

        CheckTrigger checkTrigger = GetComponent<CheckTrigger>();
        if (checkTrigger != null)
        {
            checkTrigger.SetGameManager(this);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
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
}
