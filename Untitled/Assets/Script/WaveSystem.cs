using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveSystem : MonoBehaviour
{
    public int roundEnemy;
    private int spawnedEnemy;

    private GameObject[] inGameEnemy;

    public float spawnSpeed;
    private float spawnTime;

    public GameObject[] enemy, spawnLoc;

    private void Start()
    {
        spawnLoc = GameObject.FindGameObjectsWithTag("Spawns");
    }

    private void Update()
    {
        Spawn();
    }

    public void Spawn()
    {
        spawnTime += Time.deltaTime;
        inGameEnemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (spawnTime >= spawnSpeed && spawnedEnemy <= roundEnemy)
        {
            spawnTime = 0;
            spawnedEnemy += 1;

            Instantiate(enemy[Random.Range(0, enemy.Length)], spawnLoc[Random.Range(0, spawnLoc.Length)].transform.position, spawnLoc[Random.Range(0, spawnLoc.Length)].transform.rotation);
        }

        if (spawnedEnemy >= roundEnemy && inGameEnemy == null)
        {
            print("newWave");
        }
    }
}