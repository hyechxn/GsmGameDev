using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// 플레이어의 전체 로직을 모아주는 클래스
/// </summary>
public class Player : MonoBehaviour, IPlayerMove, IPlayerInput, IPlayerRotate, IPlayerAttack
{
    private Vector2 vec2;

    [SerializeField] float speed;
    public float Speed => speed;

    [SerializeField] float rotationSpeed;

    public float RotationSpeed => rotationSpeed;

    [SerializeField] float attackCooltime;
    private float AttackCooltime => attackCooltime;

    [SerializeField] private Coroutine curAttackCoroutine;

    private bool isAttack;
    private bool isRapidMode;

    private void Update()
    {
        TryAttack();
    }

    private void FixedUpdate()
    {
        Move(vec2);
        Rotate(Camera.main.ScreenToWorldPoint(Input.mousePosition));

    }

    public void Move(Vector2 moveDirection)
    {
        transform.position += (Vector3)moveDirection * Time.deltaTime * Speed;
    }

    public void OnMoveInput(InputValue value)
    {
        vec2 = value.Get<Vector2>();
    }

    public void Rotate(Vector3 targetPos)
    {
        Vector2 newPos = targetPos - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.Euler(0, 0, rotZ - 90f), rotationSpeed * Time.deltaTime);
    }

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


