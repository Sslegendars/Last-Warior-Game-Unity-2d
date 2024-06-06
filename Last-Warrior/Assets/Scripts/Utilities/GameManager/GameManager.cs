using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    [Header("Pause Menu Settings")]    
    public GameObject pauseMenuUI;
    public static bool gameIsPaused = false;
    public GameObject finishGameMenuUI;
    public GameObject gameOverMenuUI;
    
    public GameObject penilessTMPro;
    public int _coin;

    [SerializeField] 
    private TextMeshProUGUI coinText;

    private AudioManager audioManager;
    private bool gameCompleted = false;

    // SetGameTime() variable
    private const float freezeTime = 0f;
    private const float StopFreezeTime = 1f;
    private const float endGameTimeDelay = 3f;

    // Sounds Strings Name
    private const string themeSound = "Theme";
    private const string gameOverSound = "GameOver";
    private const string finishGameSound = "YouWin";
    private const string spentMoneySound = "SpentMoney";
    private const string pennilessSound = "NotEnoughMoney";
   
    private void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
       
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P) && !gameCompleted)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();

            }
        }

    }
    public void UpdateCoinText()
    {
        coinText.text = "Coin: " + _coin.ToString();
    }
    public void SpentCoin(int spentMoneyAmount)
    {
        if (_coin >= spentMoneyAmount)
        {
            _coin -= spentMoneyAmount;
            audioManager.Play(spentMoneySound); 
            
            UpdateCoinText();           
        }
        else
        {
            
            audioManager.Play(pennilessSound);         
            penilessTMPro.SetActive(true);          
                                  
            
        }

    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        SetGameTime(StopFreezeTime);
        gameIsPaused = false;
        audioManager.Play(themeSound);
        // mainmenu sound stop
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        penilessTMPro.SetActive(false);
        SetGameTime(freezeTime);
        gameIsPaused = true;
        audioManager.Stop(themeSound);
        
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SetGameTime(StopFreezeTime);
        audioManager.Play(themeSound);

    }
    private void SetGameTime(float time)
    {
        Time.timeScale = time;
    }
    public void QuitGame()
    {
        Application.Quit();        
    }
    public void FinishGame()
    {
        StartCoroutine(FinishGameCoroutine());       
        
    }
    private IEnumerator FinishGameCoroutine()
    {
        gameCompleted = true;
        SetGameTime(0.5f);
        audioManager.StopAllSounds();
        yield return new WaitForSeconds(2f);
        SetGameTime(freezeTime);
        audioManager.Play(finishGameSound); 
        audioManager.Stop(themeSound);
        finishGameMenuUI.SetActive(true);
        //pauseMenuUI.SetActive(false);
    }
    public void GameOver()
    {
        gameCompleted = true;
        SetGameTime(freezeTime);
        audioManager.StopAllSounds();
        audioManager.Play(gameOverSound);        
        gameOverMenuUI.SetActive(true);
        //pauseMenuUI.SetActive(false);
    }
    public void RestartGame()
    {        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);

        gameOverMenuUI.SetActive(false);
        SetGameTime(StopFreezeTime);
        audioManager.Play(themeSound);
    }
    
}
