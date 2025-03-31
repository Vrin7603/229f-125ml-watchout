using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    // Function to load the gameplay scene
    public void StartCredit()
    {
        SceneManager.LoadScene("Credit");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
