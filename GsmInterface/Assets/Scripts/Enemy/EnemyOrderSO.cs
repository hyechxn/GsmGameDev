using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyOrder", menuName = "EnemyOrder")]
public class EnemyOrderSO : ScriptableObject
{
    [SerializeField] GameObject[] enemies;
    public GameObject[] Enemies => enemies;
}
