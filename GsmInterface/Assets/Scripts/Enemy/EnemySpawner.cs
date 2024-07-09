using System.Collections;
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
            for (int x = 0; x < enemyList[y].Length; ++x)
            {
                string spawnEnemyName = "Enemy";

                switch (enemyList[y][x])
                {
                    case '1':
                        spawnEnemyName = "EnemyS";
                        break;

                    case '2':
                        spawnEnemyName = "EnemyM";
                        break;
                }
                Instantiate(Resources.Load($"Prefabs/Enemies/{spawnEnemyName}"), GetOutScreenRandomPosition(), Quaternion.identity);

                yield return new WaitForSeconds(SpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
    }

    public Vector3 GetOutScreenRandomPosition()
    {
        float widthScale = (float)Screen.width / Screen.height;
        float length = Mathf.Sqrt(Mathf.Pow(Camera.main.orthographicSize, 2) + Mathf.Pow(Camera.main.orthographicSize * widthScale, 2)) + 1f;

        Vector2 direction = Random.insideUnitCircle.normalized * length;

        return direction;
    }
}