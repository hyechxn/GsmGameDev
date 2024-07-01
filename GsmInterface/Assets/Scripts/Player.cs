using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 플레이어의 전체 로직을 모아주는 클래스
/// </summary>
public class Player : MonoBehaviour, IPlayerMove, IPlayerInput, IPlayerRotate
{
    private Vector2 vec2;

    [SerializeField] float speed;
    public float Speed => speed;

    [SerializeField] float rotationSpeed;
    public float RotationSpeed => rotationSpeed;

    private void FixedUpdate()
    {
        Move(vec2);
        Rotate(Camera.main.ScreenToWorldPoint(Input.mousePosition));
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

    public void Rotate(Vector3 targetPos)
    {
        Vector2 newPos = targetPos - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, 
            Quaternion.Euler(0, 0, rotZ - 90f), rotationSpeed * Time.deltaTime);
    }

}
