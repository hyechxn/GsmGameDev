using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerInput
{
    public void OnMoveInput(InputValue value);
}