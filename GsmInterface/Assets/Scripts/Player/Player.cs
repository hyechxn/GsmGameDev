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


