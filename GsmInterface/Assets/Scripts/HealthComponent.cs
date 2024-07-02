using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamageReceiver
{
    public float startHealth;

    [field: SerializeField]
    public float Health
    {
        get; private set;
    }

    private void Start()
    {
        Health = startHealth;   
    }


    public void GetDamage(IDamage damage)
    {
        Health -= damage.Amount;
    }
}
