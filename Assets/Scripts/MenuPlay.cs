using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlay : MonoBehaviour
{
    
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
