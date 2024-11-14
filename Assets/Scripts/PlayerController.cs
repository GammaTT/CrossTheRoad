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
        // ��ǥ ��ġ�� ������ ������ �̵�
        if (isMoving)
        {
            Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            rigidbody.MovePosition(newPosition);

            // ��ǥ ��ġ�� ���������� �̵� ����
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

        // WASD �Է¿� ���� ���� ����
        if (curMoveInput.y > 0)         // ������ �̵� (W)
            targetAngle = 0;
        else if (curMoveInput.y < 0)    // �ڷ� �̵� (S)
            targetAngle = 180;
        else if (curMoveInput.x > 0)    // ������ �̵� (D)
            targetAngle = 90;
        else if (curMoveInput.x < 0)    // ���� �̵� (A)
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
