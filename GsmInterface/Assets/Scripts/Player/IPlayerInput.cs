using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///	�÷��̾� �̵����� ���� �Է��� �޽��ϴ�.
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