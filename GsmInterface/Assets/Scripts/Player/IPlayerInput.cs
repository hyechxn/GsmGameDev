using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///	플레이어 이동로직 관련 입력을 받습니다.
/// </summary>
public interface IPlayerMoveInput
{
    public Vector2 SaveInputVec2
    {
        get;
    }
    public void OnMoveInput(InputValue value);
}

public interface IPlayerRotateInput
{
    public void OnRotateInput(InputValue value);
}

public interface IPlayerAttackInput
{
    public void OnAttackInput(InputValue value);
    public void OnScrolling(InputValue value);
}