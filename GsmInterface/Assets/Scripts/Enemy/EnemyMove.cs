using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour, IMove
{
    [SerializeField] float speed;
    public float Speed => speed;

    public Vector3 GetMoveDirection()
    {
        return -transform.up * Time.deltaTime * Speed;
    }

    public void Move()
    {
        transform.position += GetMoveDirection();
    }
}
