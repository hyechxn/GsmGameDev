using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
///	�÷��̾� ���� ���� �Է��� �޽��ϴ�.
/// </summary>
public interface IPlayerInput
{
    public void OnMoveInput(InputValue value);
    public void OnAttackInput(InputValue value);

    public Vector3 MousePosInput()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}