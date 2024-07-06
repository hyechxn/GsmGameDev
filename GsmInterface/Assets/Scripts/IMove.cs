using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	�̵� ������ �޾� �̵��� �ϰ� �ӵ� ������ �����մϴ�.
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
///	�ٶ� ��ġ�� �޾� ȸ���� �ϰ� ȸ���ӵ� ������ �����մϴ�.
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
