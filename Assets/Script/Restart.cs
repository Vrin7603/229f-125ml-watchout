using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    public void Update()
    {
        RestartGame();
    }
    public void RestartGame()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Gameplay");
        }
    }
}
