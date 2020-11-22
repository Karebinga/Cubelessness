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
    [SerializeField] private GameObject player;
    
    AudioSource audioSource;
    private GameObject _obstacle;
    private static bool _gameHasStarted = false;

    [HideInInspector] public bool IsGameOnPause;
    private SpawnManager SpawnManager;

    public void Start()
    {
        IsGameOnPause = true;
        SpawnManager = FindObjectOfType<SpawnManager>();
    }

    public void StartGame()
    {
        _gameHasStarted = true;
        StartScreenUI.transform.DOScale(new Vector3(0,0, 0), 0.5f).SetUpdate(UpdateType.Normal, true);
        GetComponent<AudioSource>().Play();
    }

    void Update()
    {
        if (_gameHasStarted)
        {
            TouchPauseActivation();
        }
    }

    public void TouchPauseActivation()
    {
        if (_gameHasStarted)
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
            GetComponent<AudioSource>().Pause();
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
            GetComponent<AudioSource>().UnPause();
            pauseMenuUI.transform.DOScale(new Vector3(11, 11, 11), 1f);
            SpawnManager.StartSpawning();
        }
            
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    {
        if (_gameHasStarted)
        {
            _gameHasStarted = false;
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}