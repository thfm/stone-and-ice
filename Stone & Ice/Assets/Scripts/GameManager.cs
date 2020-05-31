using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SceneLoader sceneLoader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Endless")
            {
                sceneLoader.LoadScene("Menu");
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
