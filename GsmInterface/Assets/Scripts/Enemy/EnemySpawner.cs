using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    public float SpawnDelay => spawnDelay;

    [SerializeField] float waveDelay;
    public float WaveDelay => waveDelay;



    private void Start()
    {
        var path = Path.Combine("Assets/Data", "EnemySpawnLogic.txt");

        string[] lines = File.ReadAllLines(path);

        StartCoroutine(Spawn(lines));

    }

    IEnumerator Spawn(string[] enemyList)
    {
        for (int y = 0; y < enemyList.Length; ++y)
        {
            Debug.Log($"{y + 1}번 웨이브");
            for (int x = 0; x < enemyList[y].Length; ++x)
            {
                switch (enemyList[y][x])
                {
                    case '1':
                        Instantiate(Resources.Load("Prefabs/Enemys/EnemyS"), transform.position, Quaternion.identity);
                        break;
                    case '2':
                        Instantiate(Resources.Load("Prefabs/Enemys/EnemyM"), transform.position, Quaternion.identity);
                        break;
                }
                yield return new WaitForSeconds(SpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
    }
}