using UnityEngine;
using UnityEngine.InputSystem;

public class LevelManager : MonoBehaviour
{
   public HealthManager healthManager;
    public playerManager PlayerManager;
    public EnemySpawner EnemySpawner;
    public GameManager gameManager;
    public static LevelManager manager;
    public GameObject Deathscreen;
    public int score;
    public int alivePlayers = 0;
   public GameObject revivebutton;
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

    public void OnPlayerDeath()
    {

        alivePlayers--;

        if (alivePlayers <= 0)
        {
            GameOver();
        }
        if (EnemySpawner.currWave == 6)
        {
            revivebutton.SetActive(true);

        }
    }
    public void join(PlayerInput player)
    {
        alivePlayers++;

    }
 

    
 
}
