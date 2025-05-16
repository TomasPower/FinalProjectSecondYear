using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    
    public void LoadSpaceFlyingScene()
    {
        SceneManager.LoadScene("Space Flying");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
