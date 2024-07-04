using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// 플레이어의 회전로직을 구현하는 클래스
/// </summary>
public class PlayerRotate : MonoBehaviour, IPlayerRotateInput, IPlayerRotate
{
    [SerializeField] float rotationSpeed;

    public float RotationSpeed => rotationSpeed;

    Vector3 targetPos;

    public void OnRotateInput(InputValue value)
    {
        targetPos = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
    }

    public Quaternion GetRotation(Transform currrentTransform)
    {
        Vector2 newPos = targetPos - currrentTransform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        return Quaternion.Lerp(currrentTransform.rotation,
            Quaternion.Euler(0, 0, rotZ - 90f), rotationSpeed * Time.deltaTime);
    }
}
