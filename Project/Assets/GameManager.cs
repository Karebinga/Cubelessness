using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float restartDelay;
    [SerializeField] private GameObject completeLevelUI;
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject StartScreenUI;
    [SerializeField] private GameObject ScoreUI;
    [SerializeField] private GameObject HighScoreUI;
    [SerializeField] private GameObject Light;
    [SerializeField] private GameObject player;
    
    AudioSource audio;
    private int _score;
    public static bool GameHasStarted = false;

    [HideInInspector] public bool IsGameOnPause;
    private SpawnManager SpawnManager;
    static private int _highScore;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
        IsGameOnPause = true;
        SpawnManager = FindObjectOfType<SpawnManager>();
        HighScoreUI.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
    }

    public void StartGame()
    {
        _score = 0;
        GameHasStarted = true;
        StartScreenUI.transform.DOScale(new Vector3(0, 0, 0), 0.5f).SetUpdate(UpdateType.Normal, true);
        audio.Play();
    }

    void Update()
    {
        ScoreUI.GetComponent<TextMeshProUGUI>().text = _score.ToString();
        if (GameHasStarted)
        {
            TouchPauseActivation();
        }
    }

    public void TouchPauseActivation()
    {
        if (GameHasStarted)
        {
            if (Input.touchCount <= 0)
            {
                PauseGame();
            }
            else
            {
                UnPauseGame();
            }
        }
    }

    public void PauseGame()
    {
        if (!IsGameOnPause)
        {
            Time.timeScale = 0f;
            IsGameOnPause = true;
            audio.Pause();
            pauseMenuUI.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetUpdate(UpdateType.Normal, true);
            SpawnManager.StopSpawning();
        }
    }

    public void UnPauseGame()
    {
        if (IsGameOnPause)
        {
            Time.timeScale = 1f;
            IsGameOnPause = false;
            audio.UnPause();
            pauseMenuUI.transform.DOScale(new Vector3(11, 11, 11), 1f);
            SpawnManager.StartSpawning();
        }
            
    }

    public void EndGame()
    {
        if (GameHasStarted)
        {
            GameHasStarted = false;
            Light.SetActive(true);
            StartCoroutine(SoundFade());
            if (_score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", _score);
            }
            Invoke("Restart", restartDelay);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void PlusScore()
    {
        _score++;
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey("HighScore");
    }

    IEnumerator SoundFade()
    {
        float currentTime = 0;
        float start = audio.volume;

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            audio.pitch = Mathf.Lerp(1f, 0, currentTime / 1);
            audio.volume = Mathf.Lerp(1f, 0, currentTime / 1);
            yield return null;
        }
        yield break;
    }
}