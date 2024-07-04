using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///	플레이어 로직 관련 입력을 받습니다.
/// </summary>
public interface IPlayerInput
{
    public void OnMoveInput(InputValue value);
    public void OnAttackInput(InputValue value);
    public void OnScrolling(InputValue value);
}