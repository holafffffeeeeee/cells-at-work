using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class LevelManager : MonoBehaviour
{

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
      
    }
    public void join(PlayerInput player)
    {
        alivePlayers++;

    }

    public void reviveplayers()
    {
        for (int i = 0; i < PlayerManager.players.Count; i++) 
        {
             Health health = PlayerManager.players[i].GetComponent<Health>();
             health.Revive();
        }
        revivebutton.SetActive(false);
    }
 
}
