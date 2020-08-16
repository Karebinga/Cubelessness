using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseMenuUI;
    public GameObject GameScreen;

    public void Pause ()
    {
    pauseMenuUI.SetActive(true);
    GameScreen.SetActive(false);
    Time.timeScale = 0f;
    }

    public void Continue ()
    {
        pauseMenuUI.SetActive(false);
        GameScreen.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Menu ()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
