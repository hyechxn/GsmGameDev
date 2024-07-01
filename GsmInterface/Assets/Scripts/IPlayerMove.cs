using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerMove
{
    public float Speed
    {
        get;
    }
    void Move(Vector2 moveDirection);
}
