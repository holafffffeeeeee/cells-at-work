



 using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
public class enemyMovement : MonoBehaviour
{
   public playerManager playermanager;
    
public float monsterhealth = 1f;
    public int poängsystem;
    public id idscript;
    public float speed = 2f;
    public id2 id22;
    public List<GameObject> pathPrefabs;
    public Transform player;               // Reference to the player

    public bool destroy;
    public float chaseRange = 5f;          // How close the player has to be for the monster to chase
    public float attackRange = 1f;
    private Transform target;

    private bool chasingPlayer = true;    // Is the monster currently chasing the player?
    public Vector3 targetPosition;
   public GameManager manager;

    private void Update()
    {
        if (playermanager.players == null || playermanager.players.Count == 0)
            return;

        FindClosestPlayer();

        if (target != null)
        {
            ChasePlayer();
        }
            
        poängsystem = id22.id = 2;
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
            if (idscript.idValue == 1  && monsterhealth == 0 || poängsystem == 2 && monsterhealth == 0)
            {
                Destroy(gameObject);
                idscript.idValue++;
                poängsystem++;
            }
            manager.OnScoreZoneReached(idscript.idValue, id22.id);
        }
        
     
    }

}



