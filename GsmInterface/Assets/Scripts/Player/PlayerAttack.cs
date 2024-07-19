using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 플레이어의 공격로직을 구현하는 클래스
/// </summary>
public class PlayerAttack : MonoBehaviour, IPlayerAttackInput, IPlayerAttack
{
    private bool isAttacking;
    private bool isRapidMode;

    [SerializeField] float attackCooltime;
    private float AttackCooltime => attackCooltime;

    [SerializeField] private Coroutine curAttackCoroutine;

    public void OnAttackInput(InputValue value)
    {
        isAttacking = !isAttacking;
    }

    public void OnScrolling(InputValue value)
    {
        isRapidMode = !isRapidMode;
    }

    
    public void TryAttack()
    {
        if (isAttacking && curAttackCoroutine == null)
        {
            if (isRapidMode)
            {
                curAttackCoroutine = StartCoroutine(RapidAttack());
            }
            else
            {
                curAttackCoroutine = StartCoroutine(Attack());
            }
        }
    }


    public IEnumerator RapidAttack()
    {
        var bullet = Instantiate(Resources.Load("Prefabs/PlayerBullets/RapidBullet"), transform.position,
            Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z));
        if ((bullet as GameObject).TryGetComponent<Bullet>(out var bullet1))
        {
            bullet1.Rigid.velocity = transform.up * bullet1.BulletSpeed;
        }
        yield return new WaitForSeconds(AttackCooltime);
        curAttackCoroutine = null;
    }

    public IEnumerator Attack()
    {
        var bullet = Instantiate(Resources.Load("Prefabs/PlayerBullets/Bullet"), transform.position,
            Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z));
        if ((bullet as GameObject).TryGetComponent<Bullet>(out var bullet1))
        {
            bullet1.Rigid.velocity = transform.up * bullet1.BulletSpeed;
        }
        yield return new WaitForSeconds(AttackCooltime * 6.6f);
        curAttackCoroutine = null;
    }
}
