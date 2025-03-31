using UnityEngine;
using UnityEngine.SceneManagement;  // Import SceneManager to load scenes

public class MainMenu : MonoBehaviour
{
    // Function to load the gameplay scene
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");  
    }

    
    public void ExitGame()
    {
        Application.Quit();
    }
}
