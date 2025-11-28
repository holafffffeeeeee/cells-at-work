using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Enemy> standardEnemies = new List<Enemy>();
    public List<Enemy> hardEnemies = new List<Enemy>();
    public List<Enemy> ActiveEnemies = new List<Enemy>();

    public GameObject revivebutton;
    public int currWave = 1;
    public int waveValue;        // = number of enemies
    public float waveDuration = 10f;

    private float waveTimer;
    private float spawnTimer;
    private float spawnInterval;

    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    public List<GameObject> spawnedEnemies = new List<GameObject>();

    public Transform[] spawnPoints;
    private int spawnIndex = 1;
    [Header("Weapon Spawning")]
    [SerializeField] public GameObject[] weaponPickupPrefabs;
    [SerializeField] public Transform[] weaponSpawnPoints;
    [SerializeField] private int bossWaveInterval = 3;


    public void SpawnWeaponPickups()
    {
        if (weaponPickupPrefabs.Length == 0 || weaponSpawnPoints.Length == 0) return;

        foreach (Transform spawnPoint in weaponSpawnPoints)
        {
            int randomWeapon = Random.Range(0, weaponPickupPrefabs.Length);
            Instantiate(weaponPickupPrefabs[randomWeapon], spawnPoint.position, Quaternion.identity);
        }
    }

    void Start()
    {
        GenerateWave();
    }

    void FixedUpdate()
    {
        // Spawn enemies across the wave duration
        if (spawnTimer <= 0f)
        {
            if (enemiesToSpawn.Count > 0)
            {
                SpawnEnemy();
            }
        }
        else
        {
            spawnTimer -= Time.fixedDeltaTime;
        }

        // Count down wave timer
        waveTimer -= Time.fixedDeltaTime;

        // When time is up AND all enemies are dead → next wave
        if (waveTimer <= 0f && spawnedEnemies.Count == 0)
        {
           
            currWave++;
            GenerateWave();
            if (currWave == 6)
            {
                revivebutton.SetActive(true);

            }
        }
    }
   

    
        
        void SpawnEnemy()
    {
        GameObject enemy = Instantiate(
            enemiesToSpawn[0],
            spawnPoints[spawnIndex].position,
            Quaternion.identity
        );

        enemiesToSpawn.RemoveAt(0);
        spawnedEnemies.Add(enemy);

        // Move to next spawn point in order
        spawnIndex = (spawnIndex + 1) % spawnPoints.Length;

        spawnTimer = spawnInterval;
    }

    public void ReportDead(GameObject deadEnemy)
    {
        spawnedEnemies.Remove(deadEnemy);
    }

    void GenerateWave()
    {
        // Choose enemy difficulty set
        if (currWave < 5)

            ActiveEnemies = standardEnemies;
    else  

            ActiveEnemies = hardEnemies;
            waveDuration = 10f;
        
       
        

           
       
        
        // Spawn weapons every boss wave (every 3 waves)
        if (currWave % bossWaveInterval == 0 && currWave > 0)
        {
            SpawnWeaponPickups();
        }


        // LEVELING RULE: waveValue = how many monsters per wave
        waveValue = currWave * 5;    // Wave 1 = 5 enemies, 2 = 10, 3 = 15...

        // Generate EXACT waveValue enemies, cost-weighted
        enemiesToSpawn = GenerateCostBalancedEnemies();

        // Set spawning timing
        spawnInterval = waveDuration / Mathf.Max(1, enemiesToSpawn.Count);
        waveTimer = waveDuration;
    }

    // ------------------------------
    // COST-BALANCED MONSTER PICKING
    // ------------------------------
    List<GameObject> GenerateCostBalancedEnemies()
    {
        List<GameObject> list = new List<GameObject>();

        // Build weight list (1/cost → cheap = common, expensive = rare)
        List<float> weights = new List<float>();
        float totalWeight = 0f;

        foreach (Enemy e in ActiveEnemies)
        {
            float w = 1f / Mathf.Max(1, e.cost);
            weights.Add(w);
            totalWeight += w;
        }

        // Pick EXACT waveValue monsters using weighted chance
        for (int i = 0; i < waveValue; i++)
        {
            float rand = Random.value * totalWeight;
            float running = 0f;

            for (int j = 0; j < ActiveEnemies.Count; j++)
            {
                running += weights[j];
                if (rand <= running)
                {
                    list.Add(ActiveEnemies[j].enemyPrefab);
                    break;
                }
            }
        }

        return list;
    }
}


[System.Serializable]
public class Enemy
{
    public GameObject enemyPrefab;
    public int cost = 1;
}
