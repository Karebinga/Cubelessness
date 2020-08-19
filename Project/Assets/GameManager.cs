using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded = false;
    private static bool _gameIsStarted = false;

    public float restartDelay;
    public GameObject completeLevelUI;
    public AudioClip EndAudio;

    public void Start()
    {
        Debug.Log(_gameIsStarted);
        if (_gameIsStarted == false)
        {
            _gameIsStarted = true;
            Time.timeScale = 0f;
        }
    }

    public void Update()
    {
        if ((Input.touchCount > 0) || (Input.GetMouseButton(0)) == true)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
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
            AudioSource.PlayClipAtPoint(EndAudio, gameObject.transform.position);
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}