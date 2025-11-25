 using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerManager : MonoBehaviour
{
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public List<PlayerInput> players = new List<PlayerInput>();

    [SerializeField] private GameObject player2Prefab;


   public PlayerInputManager pim;
    public void onJoin(PlayerInput player)
    {

        players.Add(player);

        pim.playerPrefab = player2Prefab;
    
    }
    void Update()
    {
      
    }
    public void OnCanvas()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
    private static Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}
