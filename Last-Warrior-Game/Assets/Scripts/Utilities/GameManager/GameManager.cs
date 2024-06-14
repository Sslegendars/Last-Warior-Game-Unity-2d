using System.Collections;
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

    public static GameManager Instance;
    
    public GameObject penilessTMPro;
    public int _coin;

    [SerializeField] 
    private TextMeshProUGUI coinText;

    //private AudioManager audioManager;
    private bool gameCompleted = false;

    // SetGameTime() variable
    private const float freezeTime = 0f;
    private const float StopFreezeTime = 1f;
    private const float endGameTimeDelay = 3f;

    // Sounds Strings Name
   
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
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
            AudioManager.Instance.Play(AudioManager.spentCoinSoundName);             
            UpdateCoinText();           
        }
        else
        {
            AudioManager.Instance.Play(AudioManager.notEnoughCoinSoundName);                    
            penilessTMPro.SetActive(true);     
                             
        }

    }
    
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        SetGameTime(StopFreezeTime);
        gameIsPaused = false;
        AudioManager.Instance.Play(AudioManager.themeSoundName);       
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        penilessTMPro.SetActive(false);
        SetGameTime(freezeTime);
        gameIsPaused = true;
        AudioManager.Instance.Stop(AudioManager.themeSoundName);
              
        
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SetGameTime(StopFreezeTime);
        AudioManager.Instance.Play(AudioManager.themeSoundName);

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
        AudioManager.Instance.StopAllSounds();
        yield return new WaitForSeconds(2f);
        SetGameTime(freezeTime);
        AudioManager.Instance.Play(AudioManager.winSoundName);        
        finishGameMenuUI.SetActive(true);        
    }
    public void GameOver()
    {
        gameCompleted = true;
        SetGameTime(freezeTime);
        AudioManager.Instance.StopAllSounds();
        AudioManager.Instance.Play(AudioManager.gameOverSoundName);
        gameOverMenuUI.SetActive(true);       
    }
    public void RestartGame()
    {        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        gameOverMenuUI.SetActive(false);
        SetGameTime(StopFreezeTime);
        AudioManager.Instance.Play(AudioManager.themeSoundName);
    }
    
}
