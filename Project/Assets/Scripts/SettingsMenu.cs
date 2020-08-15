using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject aboutMenuUI;


    public void Settings ()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void Back ()
    {
        pauseMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void BackAbout ()
    {
        aboutMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void About ()
    {
        aboutMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }
}
