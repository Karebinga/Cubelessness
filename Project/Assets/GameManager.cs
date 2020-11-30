using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _startScreenUI;
    [SerializeField] private GameObject _scoreText;
    [SerializeField] private GameObject _highScoreUI;
    [SerializeField] private GameObject _scoreUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _light;

    [SerializeField] private float _restartDelay;

    private AudioSource _audio;
    private int _score;
    private SpawnManager _spawnManager;

    public bool GameHasStarted = false;
    [HideInInspector] public bool IsGameOnPause;

    void Start()
    {
        IsGameOnPause = true;
        _highScoreUI.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("HighScore").ToString();
        _spawnManager = FindObjectOfType<SpawnManager>();
        _audio = GetComponent<AudioSource>();
        _audio.Play();
        Time.timeScale = 0;
        _audio.pitch = Time.timeScale;
    }

    public void StartGame()
    {
        _score = 0;
        _startScreenUI.transform.DOScale(new Vector3(0, 0, 0), 0.5f).SetUpdate(UpdateType.Normal, true);
        GameHasStarted = true;
    }

    void Update()
    {
        _scoreText.GetComponent<TextMeshProUGUI>().text = _score.ToString();
        if (GameHasStarted)
        {
            TouchPauseActivation();
        }
        
    }

    void TouchPauseActivation()
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
            _audio.pitch = Time.timeScale;
            _pauseMenuUI.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetUpdate(UpdateType.Normal, true);
            _scoreUI.transform.DOScale(new Vector3(1, 1, 1), 0.5f).SetUpdate(UpdateType.Normal, true);
            _spawnManager.StopSpawning();
        }
    }

    public void UnPauseGame()
    {
        if (IsGameOnPause)
        {
            Time.timeScale = 1f;
            IsGameOnPause = false;
            _audio.pitch = Time.timeScale;
            _pauseMenuUI.transform.DOScale(new Vector3(11, 11, 11), 1f);
            _scoreUI.transform.DOScale(new Vector3(0, 0, 0), 0.2f);
            _spawnManager.StartSpawning();
        }
            
    }

    public void EndGame()
    {
        if (GameHasStarted)
        {
            GameHasStarted = false;
            StartCoroutine(SoundFade());
            _light.SetActive(true);
            if (_score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", _score);
            }
            Invoke("Restart", _restartDelay);
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


    IEnumerator SoundFade()
    {
        float currentTime = 0;
        float start = _audio.volume;

        while (currentTime < 1)
        {
            currentTime += Time.deltaTime;
            _audio.pitch = Mathf.Lerp(1f, 0, currentTime / 1);
            _audio.volume = Mathf.Lerp(1f, 0, currentTime / 1);
            yield return null;
        }
        yield break;
    }
}