using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// �÷��̾��� �̵������� �����ϴ� Ŭ����
/// </summary>
public class PlayerMove : MonoBehaviour, IPlayerMoveInput, IPlayerMove
{

    [SerializeField] float speed;
    public float Speed => speed;

    Vector2 saveInputVec2;
    public Vector2 SaveInputVec2 { get => saveInputVec2; }

    public void OnMoveInput(InputValue value)
    {
        saveInputVec2 = value.Get<Vector2>();
    }

    public Vector3 GetMoveDirection()
    {
        return saveInputVec2 * Time.deltaTime * Speed;
    }

    public void Move()
    {
        transform.position += GetMoveDirection();
    }
}
