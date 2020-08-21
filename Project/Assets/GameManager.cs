using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded = false;
    public static bool gameIsStarted = false;

    public float restartDelay;
    public GameObject completeLevelUI;
    public AudioClip EndAudio;
    AudioSource audioSource;
    public PauseMenu pause;

    private void Start()
    {
        gameIsStarted = true;
    }

   /* void Update()
    {
        if (_gameHasEnded == false)
        {
            if (Input.touchCount < 1)
            {
                Time.timeScale = 0f;
                GetComponent<AudioSource>().Pause();
            }
            else
            {
                Time.timeScale = 1f;
                GetComponent<AudioSource>().UnPause();
            }
        }
    }
    */

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
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}