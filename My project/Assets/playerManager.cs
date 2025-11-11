using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerManager : MonoBehaviour
{
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public List<PlayerInput> players = new List<PlayerInput>();
    
    public void onJoin(PlayerInput player)
    {

        players.Add(player);
    }
    public void OnCanvas()
    {
        canvas.SetActive(false);
        Time.timeScale = 1;
    }
    
}
