using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// �÷��̾��� ��ü ������ ����ִ� Ŭ����
/// </summary>
public class Player : MonoBehaviour
{

    PlayerMove playerMove;
    PlayerRotate playerRotate;
    PlayerAttack playerAttack;

    private void Start()
    {
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


