using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : MonoBehaviour, IObstacleSpawner, IBackgroundScroller
{
    [SerializeField]
    private List<GameObject> obstacleList = new List<GameObject>();
    [SerializeField]
    private float[] spawnDelayArray = new float[2];

    public float[] SpawnDelayArrray => spawnDelayArray;
    public void OnSpawnObstacle()
    {
        StartCoroutine(SpawnObstacles());
    }
    public void OnBacgroundScoll()
    {
        StartCoroutine(BackgroundScrolling());
    }
    public void SpawnObstacle()
    {

    }
    public void BackgroundScroll()
    {
        Debug.Log("asdf");
    }
    private float WaitForSecond()
    {
        float waitingSeconds;

        waitingSeconds = Random.Range(spawnDelayArray[0], spawnDelayArray[1]);

        return waitingSeconds;
    }
    private IEnumerator SpawnObstacles()
    {
        while(true)
        {
            SpawnObstacle();

            yield return new WaitForSeconds(WaitForSecond());
        }
    }
    private IEnumerator BackgroundScrolling()
    {
        while(true)
        {
            BackgroundScroll();

            yield return null;
        }
    }
}
