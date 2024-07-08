using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ظ� �Դ� �������̽�
/// </summary>
public interface IDamageReceiver
{
    public void GetDamage(IDamage damageAmount);
}

/// <summary>
/// ���ظ� �ִ� �������̽�
/// </summary>
public interface IDamage
{
    public float Amount { get; }
}
