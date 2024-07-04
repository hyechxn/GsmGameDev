using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IDamage
{
    public Rigidbody2D Rigid
    {
        get
        {
            return rigid;
        }
        private set { rigid = value; }
    }
    [SerializeField] private Rigidbody2D rigid;

    [SerializeField] float bulletSpeed;
    public float BulletSpeed => bulletSpeed;

    [SerializeField] float damage = 1;
    public float Amount => damage;

    [SerializeField] float lifeTime;
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<IDamageReceiver>(out var damageReceiver))
        {
            damageReceiver.GetDamage(this);
            Destroy(gameObject);
        }
    }
}
