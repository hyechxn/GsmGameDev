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
    void Move(Vector2 moveDirection);
}
