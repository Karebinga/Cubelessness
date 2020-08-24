using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public GameObject settingsMenuUI;
    public GameObject aboutMenuUI;
    public GameObject startMenuUI;


    public void Settings ()
    {
        pauseMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
        startMenuUI.SetActive(false);
    }

    public void Back ()
    {
        startMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void BackAbout ()
    {
        aboutMenuUI.SetActive(false);
        settingsMenuUI.SetActive(true);
    }

    public void BackStart()
    {
        settingsMenuUI.SetActive(false);
    }

    public void About ()
    {
        aboutMenuUI.SetActive(true);
        settingsMenuUI.SetActive(false);
    }

    public void Pause()
    {
        Debug.Log("Mute");
        AudioListener.pause = true;
    }

    public void UnPause()
    {
        Debug.Log("UnMute");
        AudioListener.pause = false;
    }
}
