using Characters;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject failPanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private AudioSource musicGame;
    [SerializeField] private AudioSource musicMenu;
    [SerializeField] private Text gameScoreText;
    [SerializeField] private Text failScoreText;
    [SerializeField] private Text pauseScoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private Text fpsShowText;

    private bool _isMusicOn;
    private int _score;
    private int _highScore;
        
    private float _timerFPS, _refreshFPS, _avgFrameRateFPS;
    private string _displayFPS = "{0} FPS";

    private Player _player;

    private void Awake()
    {
       CheckHighScore();
    }

    private void Start()
    {
        _score = 0;
        EnemyBase.OnEnemyDeadScore += OnEnemyKilled;
        Player.OnPlayerDead += OnPlayerDeath;
    }

    private void OnDisable()
    {
        EnemyBase.OnEnemyDeadScore -= OnEnemyKilled;
        Player.OnPlayerDead -= OnPlayerDeath;
    }

    private void Update()
    {
        ShowScore();
        ShowFPS();
    }

    public void CheckHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            _highScore = PlayerPrefs.GetInt("HighScore", _highScore);
        }
    }

    private void ShowFPS()
    {
        float timelapseFPS = Time.smoothDeltaTime;
        _timerFPS = _timerFPS <= 0 ? _refreshFPS : _timerFPS -= timelapseFPS;

        if (_timerFPS <= 0)
        {
            _avgFrameRateFPS = (int)(1f / timelapseFPS);
            fpsShowText.text = string.Format(_displayFPS, _avgFrameRateFPS.ToString());
        }
    }

    public void ShowScore()
    {
        gameScoreText.text = _score.ToString();
        failScoreText.text = _score.ToString();
        pauseScoreText.text = _score.ToString();
        highScoreText.text = _highScore.ToString();
    }

    public void OnEnemyKilled()
    {
        _score++;
        HighScore();
    }

    public void HighScore()
    {
        if (_score>_highScore)
        {
            _highScore = _score;
            PlayerPrefs.SetInt("HighScore",_highScore);
        }
    }

    public void OnPlayerDeath()
    {
        EnemyBase.OnEnemyDeadScore -= OnEnemyKilled;
        OpenFailPanel();
    }
        
    public void OpenPausePanel()
    {
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
        menuPanel.SetActive(false);
        gamePanel.SetActive(false);
        failPanel.SetActive(false);
        musicGame.Pause();
        musicMenu.Play();
        Time.timeScale = 0f;
    }
        
    public void ClosePausePanel()
    {
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
        menuPanel.SetActive(false);
        gamePanel.SetActive(true);
        failPanel.SetActive(false);
        musicGame.Play();
        musicMenu.Stop();
        
        Time.timeScale = 1f;
    }
        

    public void OpenGamePanel()
    {
        gamePanel.SetActive(true);
        pauseButton.SetActive(true);
        menuPanel.SetActive(false);
        pausePanel.SetActive(false);
        failPanel.SetActive(false);
            
        musicGame.Play();
        musicMenu.Stop();
            
        Time.timeScale = 1f;
    }

    public void OpenNewGame()
    {
        Invoke(nameof(GameScene),0.5f);
        Time.timeScale = 1f;
        musicGame.Play();
        musicMenu.Stop();
    }
    
    public void OpenMenuPanel()
    {
        Invoke(nameof(MenuScene),0.5f);
        Time.timeScale = 1f;
        musicGame.Stop();
        musicMenu.Play();
    }

    public void GameScene()
    {
        SceneManager.LoadScene(1);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenFailPanel()
    {
        pauseButton.SetActive(false);
        gamePanel.SetActive(false);
        pausePanel.SetActive(false);
        menuPanel.SetActive(false);
        failPanel.SetActive(true);
        
        musicGame.Stop();
        musicMenu.Play();
            
        Time.timeScale = 0f;
    }

    public void MusicChange()
    {
        if (!_isMusicOn)
        {
            AudioListener.volume = 1f;
            _isMusicOn = true;
                
        }
        else if (_isMusicOn)
        {
            AudioListener.volume = 0f;
            _isMusicOn = false;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}