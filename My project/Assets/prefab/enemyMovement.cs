using UnityEngine;
using System.Collections.Generic;

public class enemyMovement : MonoBehaviour
{
    public playerManager playermanager;

    public float monsterhealth = 1f;
    public float speed = 2f;

    public float chaseRange = 5f;
    private Transform target;

    public GameManager manager;

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
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet == null) return;

        // ---- apply damage ----
        monsterhealth -= bullet.damage;

        if (monsterhealth <= 0)
        {
            manager.OnScoreZoneReached(bullet.shooterID);
            Destroy(gameObject);
        }

        Destroy(collision.gameObject); // destroy bullet
    }
}

