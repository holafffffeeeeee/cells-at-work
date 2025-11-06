using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void QuitGame()
    {
        Debug.Log("Spelet avslutas, men det funkar bara i build!");
        Application.Quit();
    }
}
