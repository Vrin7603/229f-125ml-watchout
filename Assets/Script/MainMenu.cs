using UnityEngine;
using UnityEngine.SceneManagement;  // Import SceneManager to load scenes

public class MainMenu : MonoBehaviour
{
    // Function to load the gameplay scene
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
       
    }

    
    public void StartCredit()
    {
        SceneManager.LoadScene("Credit");
    }



    public void ExitGame() 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();  
        }
    }
   
     


}
