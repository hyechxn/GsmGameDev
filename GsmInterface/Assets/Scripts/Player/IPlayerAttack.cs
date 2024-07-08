using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerAttack : IAttack
{
    public void TryAttack();
    public IEnumerator RapidAttack();
}
