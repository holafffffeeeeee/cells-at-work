



 using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class enemyMovement : MonoBehaviour
{


    public float monsterhealth = 10f;


    public float speed = 2f;

    public List<GameObject> pathPrefabs;
    public Transform player;               // Reference to the player


    public float chaseRange = 5f;          // How close the player has to be for the monster to chase
    public float attackRange = 1f;


    private bool chasingPlayer = true;    // Is the monster currently chasing the player?
    public Vector3 targetPosition;



    void Update()
    {
        chasingPlayer = true;

        if (chasingPlayer == true)
        {
            ChasePlayer();
        }






    }
    private void ChasePlayer()
    {
        // Move towards the player's position
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }


}



