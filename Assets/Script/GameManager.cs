using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameOverPanel;
    [SerializeField] private TMP_Text currentText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private Button restartButton;

    private const string SCORE = "Score";
    private const string HIGHSCORE = "HighScore";
    private const string GAMESCENE = "GameScene";

    public Camera mainCam;
    private int randomIndex;
    [SerializeField] private Color[] colorToChange;

    private AudioManager audioManager; // Declare AudioManager variable

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        audioManager = AudioManager.Instance;
    }

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
        GameOverPanel.SetActive(false);
        restartButton.onClick.RemoveAllListeners();
        restartButton.onClick.AddListener(RestartLevel);

        currentText.text = PlayerPrefs.GetInt(SCORE).ToString();
        highScoreText.text = PlayerPrefs.GetInt(HIGHSCORE).ToString();
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
        ApplyColor();
    }

    public void GameOver()
    {
        if (audioManager != null)
        {
            audioManager.PlaySound(SoundName.GameOver); // Play GameOver sound
        }

        if (score > PlayerPrefs.GetInt(HIGHSCORE))
        {
            PlayerPrefs.SetInt(HIGHSCORE, score);
        }

        PlayerPrefs.SetInt(SCORE, score);

        currentText.text = PlayerPrefs.GetInt(SCORE).ToString();
        highScoreText.text = PlayerPrefs.GetInt(HIGHSCORE).ToString();

        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(GAMESCENE);
        Time.timeScale = 1;
    }

    private void ApplyColor()
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

    private void ChangeColor()
    {
        randomIndex = Random.Range(0, colorToChange.Length);
        mainCam.backgroundColor = colorToChange[randomIndex];
    }
}
