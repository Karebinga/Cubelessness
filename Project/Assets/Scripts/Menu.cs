using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Why");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
