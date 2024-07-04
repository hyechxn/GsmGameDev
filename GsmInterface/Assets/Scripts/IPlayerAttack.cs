using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttack
{
    public void TryAttack();
    public IEnumerator RapidAttack();
    public IEnumerator Attack();
}
