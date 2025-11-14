



 using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
public class enemyMovement : MonoBehaviour
{
   public playerManager playermanager;
    
    public float monsterhealth = 10f;


    public float speed = 2f;

    public List<GameObject> pathPrefabs;
    public Transform player;               // Reference to the player


    public float chaseRange = 5f;          // How close the player has to be for the monster to chase
    public float attackRange = 1f;
    private Transform target;

    private bool chasingPlayer = true;    // Is the monster currently chasing the player?
    public Vector3 targetPosition;


    private void Update()
    {
        if (playermanager.players == null || playermanager.players.Count == 0)
            return;

        FindClosestPlayer();

        if (target != null)
            ChasePlayer();
    }

    public void FindClosestPlayer()
    {
        float closestDistance = Mathf.Infinity;
        Transform closestPlayer = null;

        foreach (var p in playermanager.players)
        {
            if (p == null) continue;

            float distance = Vector2.Distance(transform.position, p.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestPlayer = p.transform;
            }
        }

        // Only chase if within range
        if (closestPlayer != null && closestDistance <= chaseRange)
            target = closestPlayer;
        else
            target = null;
    }

    public void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );
    }

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}



