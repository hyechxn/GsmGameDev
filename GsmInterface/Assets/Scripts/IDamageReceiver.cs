using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 피해를 입는 인터페이스
/// </summary>
public interface IDamageReceiver
{
    public void GetDamage(IDamage damageAmount);
}

/// <summary>
/// 피해를 주는 인퍼테이스
/// </summary>
public interface IDamage
{
    public float Amount { get; }
}
