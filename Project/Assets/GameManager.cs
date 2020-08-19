using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded = false;

    public float restartDelay;
    public GameObject completeLevelUI;
    public AudioClip EndAudio;

    public void CompleteLevel ()
    {
        Time.timeScale = 0f;
        completeLevelUI.SetActive(true);
    }

    public void EndGame ()
    { 
        if (_gameHasEnded == false)
        {
            _gameHasEnded = true;
            AudioSource.PlayClipAtPoint(EndAudio, gameObject.transform.position);
            Invoke("Restart", restartDelay);
        }
    }

    public void Restart ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}