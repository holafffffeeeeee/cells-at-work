using UnityEngine;

public class LevelManager : MonoBehaviour
{
public GameManager gameManager;
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
      gameManager.ScoreTextleft.SetActive(false);
        gameManager.ScoreTextright.SetActive(false);
     

    }

    public void ReplayGame()
    {
        Deathscreen.SetActive(false);
        Application.LoadLevel(Application.loadedLevel);
    }
   
}
