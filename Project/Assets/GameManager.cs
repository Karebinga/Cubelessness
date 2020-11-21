using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded = false;
    private static bool _gameHasStarted = false;
    private TextMeshProUGUI _levelText;
    private int _levelNum = 1;
    private int _sceneNum;

    public float restartDelay;
    public GameObject completeLevelUI;
    public GameObject pauseMenuUI;
    public GameObject StartScreenUI;
    public GameObject player;

    public AudioClip EndAudio;
    AudioSource audioSource;
    public GameObject Level;

    public PlayerMovementTouch movement;
    

   void Update()
    {
        if (_gameHasStarted == true)
        {
            TouchPauseActivation();
        }
    }

    public void TouchPauseActivation()
    {
        if (_gameHasEnded == false)
        {
            if (Input.touchCount <= 0)
            {
                movement.Speed = 0;
                GetComponent<AudioSource>().Pause();
                pauseMenuUI.transform.DOScale(new Vector3(1, 1, 1), 0.5f);
            }
            else
            {
                movement.Speed = 30;
                GetComponent<AudioSource>().UnPause();
                pauseMenuUI.transform.DOScale(new Vector3(11, 11, 11), 1f);
            }
            
        }
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (_gameHasEnded == false)
        {
            _gameHasEnded = true;
            Invoke("Restart", restartDelay);
            audioSource = GetComponent<AudioSource>();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void Start()
    {
        _sceneNum = SceneManager.sceneCountInBuildSettings;
        movement.Speed = 0;

        if (_gameHasStarted == true)
        {
            StartScreenUI.SetActive(false);
            Level.SetActive(true);
            movement.Speed = 30;
        }
    }

    public void StartGame()
    {
        _gameHasStarted = true;
        Level.SetActive(true);
        movement.Speed = 30;
        StartScreenUI.transform.DOScale(new Vector3(11, 11, 11), 1f);
    }

    public void LevelSelectNext()
    {
        _levelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        _levelNum = Mathf.Clamp(_levelNum + 1, 1, _sceneNum);
        _levelText.text = "Level " + _levelNum;
    }

    public void LevelSelectPrevious()
    {
        _levelText = GameObject.Find("Level").GetComponentInChildren<TextMeshProUGUI>();
        _levelNum = Mathf.Clamp(_levelNum - 1, 1, _sceneNum);
        _levelText.text = "Level " + _levelNum;
    }
}