using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay;

    public GameObject completeLevelUI;
    public AudioClip clip;

    public void CompleteLevel ()
    {
        Time.timeScale = 0f;
        completeLevelUI.SetActive(true);
    }

    public void EndGame()
    { 
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            Invoke("Restart", restartDelay);
        }
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}