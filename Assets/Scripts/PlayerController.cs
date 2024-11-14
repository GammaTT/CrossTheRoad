using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveDistance;
    [SerializeField] private float moveSpeed;

    private Rigidbody rigidbody;
    private Vector2 curMoveInput;
    private Vector3 targetPosition;
    private bool isMoving = false;

    public Action MoveAction;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        targetPosition = transform.position;
    }

    private void Start()
    {
        isMoving = false;
    }

    private void FixedUpdate()
    {
        // 목표 위치에 도달할 때까지 이동
        if (isMoving)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            rigidbody.MovePosition(newPosition);

            // 목표 위치에 도달했으면 이동 멈춤
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }

    private void SetDirection(string inputChar)
    {
        //curMoveInput = curMoveInput.normalized;

        float targetAngle = 0;

        // WASD 입력에 따른 각도 설정
        if (curMoveInput.y > 0)         // 앞으로 이동 (W)
            targetAngle = 0;
        else if (curMoveInput.y < 0)    // 뒤로 이동 (S)
            targetAngle = 180;
        else if (curMoveInput.x > 0)    // 오른쪽 이동 (D)
            targetAngle = 90;
        else if (curMoveInput.x < 0)    // 왼쪽 이동 (A)
            targetAngle = -90;

        Vector3 currentRotation = transform.eulerAngles;
        currentRotation.y = targetAngle;
        transform.eulerAngles = currentRotation;
    }

    private void Move()
    {
        //rigidbody.AddForce((transform.forward + Vector3.up) * movePower, ForceMode.Impulse);

        //transform.position += transform.forward * movePower;

        targetPosition = transform.position + transform.forward * moveDistance;
        isMoving = true;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMoveInput = context.ReadValue<Vector2>();
            SetDirection(context.control.name);
            Move();
            MoveAction?.Invoke();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMoveInput = Vector2.zero;
        }
    }
}
