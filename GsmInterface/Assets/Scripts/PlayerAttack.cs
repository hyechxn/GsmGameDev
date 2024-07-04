using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// �÷��̾��� ���ݷ����� �����ϴ� Ŭ����
/// </summary>
public class PlayerAttack : MonoBehaviour, IPlayerAttackInput, IPlayerAttack
{
    private bool isAttack;
    private bool isRapidMode;

    [SerializeField] float attackCooltime;
    private float AttackCooltime => attackCooltime;

    [SerializeField] private Coroutine curAttackCoroutine;

    public void OnAttackInput(InputValue value)
    {
        isAttack = !isAttack;
    }

    public void OnScrolling(InputValue value)
    {
        isRapidMode = !isRapidMode;
    }

    
    public void TryAttack()
    {
        if (isAttack && curAttackCoroutine == null)
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
        var bullet = Instantiate(Resources.Load("Prefabs/RapidBullet"), transform.position,
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
        var bullet = Instantiate(Resources.Load("Prefabs/Bullet"), transform.position,
            Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z));
        if ((bullet as GameObject).TryGetComponent<Bullet>(out var bullet1))
        {
            bullet1.Rigid.velocity = transform.up * bullet1.BulletSpeed;
        }
        yield return new WaitForSeconds(AttackCooltime * 10);
        curAttackCoroutine = null;
    }
}