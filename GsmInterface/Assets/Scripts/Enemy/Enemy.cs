using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    EnemyRotate enemyRotate;
    EnemyMove enemyMove;
    EnemyAttack enemyAttack;

    private void Awake()
    {
        enemyRotate = GetComponent<EnemyRotate>();
        enemyMove = GetComponent<EnemyMove>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    private void Start()
    {
        StartCoroutine(enemyAttack.Attack());
    }

    private void FixedUpdate()
    {
        enemyRotate.Rotate();
        enemyMove.Move();
    }
}
