using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	이동 방향을 받아 이동을 하고 속도 정보를 저장합니다.
/// </summary>
public interface IMove
{
    public float Speed
    {
        get;
    }
    Vector3 GetMoveDirection();

    public void Move();
}


/// <summary>
///	바라볼 위치을 받아 회전을 하고 회전속도 정보를 저장합니다.
/// </summary>
public interface IRotate
{
    public float RotationSpeed
    {
        get;
    }
    public Quaternion GetRotation(Transform currrentTransform);

    public void Rotate();
}
