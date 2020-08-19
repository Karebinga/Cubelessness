using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    private TextMeshProUGUI _levelText;
    private int _levelNum = 1;
    private int _sceneNum;

    public void Start ()
    {
        _sceneNum = SceneManager.sceneCountInBuildSettings - 1;
    }

    public void StartGame ()
    {
        SceneManager.LoadScene(_levelNum);
    }

    public void LevelSelectNext ()
    {
        _levelText = GameObject.Find("Level").GetComponent<TextMeshProUGUI>();
        _levelNum = Mathf.Clamp(_levelNum + 1, 1, _sceneNum);
        _levelText.text = "Level " + _levelNum;
    }

    public void LevelSelectPrevious ()
    {
        _levelText = GameObject.Find("Level").GetComponentInChildren<TextMeshProUGUI>();
        _levelNum = Mathf.Clamp(_levelNum - 1, 1, _sceneNum);
        _levelText.text = "Level " + _levelNum;
    }
}
