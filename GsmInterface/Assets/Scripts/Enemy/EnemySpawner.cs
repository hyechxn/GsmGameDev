using System;
using System.Collections;
using System.IO;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 작성자 : 나혜찬
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;
    public float SpawnDelay => spawnDelay;

    [SerializeField] float waveDelay;
    public float WaveDelay => waveDelay;

    [SerializeField] EnemyOrderSO[] enemyOrders;
    public EnemyOrderSO[] EnemyOrders => enemyOrders;
    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        for (int x = 0; x < enemyOrders.Length; x++)
        {
            for (int y = 0; y < enemyOrders[x].Enemies.Length; y++)
            {
                Instantiate(enemyOrders[x].Enemies[y], GetOutScreenRandomPosition(), Quaternion.identity);

                yield return new WaitForSeconds(SpawnDelay);
            }
            yield return new WaitForSeconds(WaveDelay);
        }
    }

    public Vector3 GetOutScreenRandomPosition()
    {
        float widthScale = (float)Screen.width / Screen.height;
        float length = Mathf.Sqrt(Mathf.Pow(Camera.main.orthographicSize, 2) + Mathf.Pow(Camera.main.orthographicSize * widthScale, 2)) + 1f;

        Vector2 randomPosition = Random.insideUnitCircle.normalized * length;

        return randomPosition;
    }
}