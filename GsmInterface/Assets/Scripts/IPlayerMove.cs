using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///	이동 방향을 받아 이동을 하고 속도 정보를 저장합니다.
/// </summary>
public interface IPlayerMove
{
    public float Speed
    {
        get;
    }
    void Move(Vector2 moveDirection);
}
