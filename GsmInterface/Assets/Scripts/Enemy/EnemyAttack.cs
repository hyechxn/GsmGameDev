using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour, IAttack, IDamage
{
    [SerializeField] float damage = 1;
    public float Amount => damage;

    [SerializeField] float attackCooltime;
    private float AttackCooltime => attackCooltime;

    [SerializeField] string bulletType;
    private string BulletType => bulletType;


    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(AttackCooltime);

        var bullet = Instantiate(Resources.Load($"Prefabs/EnemyBullets/{bulletType}"), transform.position,
            Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z - 180f));

        if ((bullet as GameObject).TryGetComponent<Bullet>(out var _bullet))
        {
            _bullet.Rigid.velocity = -transform.up * _bullet.BulletSpeed;
        }
        StartCoroutine(Attack());
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IDamageReceiver>(out var damageReceiver))
        {
            damageReceiver.GetDamage(this);
        }
    }
}
