using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Wave : IWave
{
    public Enemy EnemyPrefab;

    public float TimeToSpawn;
    public Transform[] Points;
    public int Count;

    private float timer;
    
    void Start()
    {
        timer = TimeToSpawn;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && Count > 0) {
            // создание объекта
            Enemy enemy = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            enemy.Points = Points;

            Count--;
            if (Count <= 0) {
                isActive = false;
                return;
            }

            timer = TimeToSpawn;
        }
    }
}
