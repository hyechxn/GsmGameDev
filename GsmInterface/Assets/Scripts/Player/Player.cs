using UnityEngine;

/// <summary>
/// �÷��̾��� ��ü ������ ����ִ� Ŭ����
/// </summary>
public class Player : MonoBehaviour
{
    public static Player instance;

    PlayerMove playerMove;
    PlayerRotate playerRotate;
    PlayerAttack playerAttack;

    private void Awake()
    {
        instance = this;

        playerMove = GetComponent<PlayerMove>();
        playerRotate = GetComponent<PlayerRotate>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Update()
    {
        playerAttack.TryAttack();
    }

    private void FixedUpdate()
    {
        playerMove.Move();
        playerRotate.Rotate();

    }
}


