using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// �÷��̾��� ��ü ������ ����ִ� Ŭ����
/// </summary>
public class Player : MonoBehaviour, IPlayerMove, IPlayerInput
{
    private Vector2 vec2;

    [SerializeField] float speed;
    public float Speed => speed;

    private void FixedUpdate()
    {
        Move(vec2);
    }

    public void Move(Vector2 moveDirection)
    {
        transform.position += (Vector3)moveDirection * Time.deltaTime * Speed;
    }

    public void OnMoveInput(InputValue value)
    {
        vec2 = value.Get<Vector2>();
    }

    public void OnAttackInput(InputValue value)
    {

    }
}
