using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 플레이어의 공격로직을 구현하는 클래스
/// </summary>
public class PlayerAttack : MonoBehaviour, IPlayerAttackInput, IPlayerAttack, IPowerUpReceiver
{
    private bool isAttacking;
    private bool isRapidMode;

    [SerializeField] private List<GameObject> powerUpBullets = new List<GameObject>();
    [SerializeField] float attackCooltime;
    [SerializeField] private Coroutine curAttackCoroutine;
    [SerializeField] private int powerLevel = 1;
    private float AttackCooltime => attackCooltime;

    public List<GameObject> PowerUpBullets => powerUpBullets;


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
        var bullet = Instantiate(Resources.Load($"Prefabs/PlayerBullets/{powerUpBullets[powerLevel]}"), transform.position,
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
        var bullet = Instantiate(Resources.Load($"Prefabs/PlayerBullets/{powerUpBullets[powerLevel]}"), transform.position,
            Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z));
        if ((bullet as GameObject).TryGetComponent<Bullet>(out var bullet1))
        {
            bullet1.Rigid.velocity = transform.up * bullet1.BulletSpeed;
        }
        yield return new WaitForSeconds(AttackCooltime * 6.6f);
        curAttackCoroutine = null;
    }

    public void PowerChange(IPowerUpProvider powerUpProvider)
    {
        powerLevel += powerUpProvider.PowerAmount;
    }
}
