using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	�̵� ������ �޾� �̵��� �ϰ� �ӵ� ������ �����մϴ�.
/// </summary>
public interface IPlayerMove
{
    public float Speed
    {
        get;
    }
    Vector3 GetMoveDirection();
}


/// <summary>
///	�ٶ� ��ġ�� �޾� ȸ���� �ϰ� ȸ���ӵ� ������ �����մϴ�.
/// </summary>
public interface IPlayerRotate
{
    public float RotationSpeed
    {
        get;
    }
    public Quaternion GetRotation(Transform currrentTransform);
}
