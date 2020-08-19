using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject GameScreenUI;

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        GameScreenUI.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Continue ()
    {
        pauseMenuUI.SetActive(false);
        GameScreenUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Menu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
