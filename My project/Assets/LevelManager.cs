using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public static LevelManager manager;
    public GameObject Deathscreen;
    public int score;

    private void Start()
    {
        Deathscreen.SetActive(false);
    }
    private void Awake()
    {

        manager = this;
    }

    public void GameOver()
    {
        Deathscreen.SetActive(true);
      
    }

    public void ReplayGame()
    {
        Deathscreen.SetActive(false);
    }
   
}
