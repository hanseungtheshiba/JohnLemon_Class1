using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator; // ����
    private Rigidbody rb;
    private Vector3 movement = Vector3.zero;
    private Quaternion rotation = Quaternion.identity;

    [HeaderAttribute("ȸ�� �ӵ�")]
    public float turnSpeed = 20f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        // movement.Set : ������ ���� ����
        movement.Set(horizontal, 0f, vertical);
        // movement.Normalize() : ���� ����ȭ (���̸� 1�� ����)
        movement.Normalize();
        // �Է� üũ
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        // �ִϸ������� �Ķ���͸� �Է�
        animator.SetBool("IsWalking", isWalking);
        // desiredFoward : ���� �ٶ󺸴� ����
        // Time.fixedDeltaTime : FixedUpdate �� �����Ӵ� �ɸ��� �ð�
        Vector3 desiredFoward = Vector3.RotateTowards(transform.forward, movement, 
            turnSpeed * Time.fixedDeltaTime, 0f);
        // Quaternion : ���⺤�͸� ���� �Ĵٺ��� �����ش�
        rotation = Quaternion.LookRotation(desiredFoward);
    }

    private void OnAnimatorMove()
    {
        // rb.MovePosition : �����ٵ� ���� ��ġ �̵�
        // animator.deltaPosition.magnitude : �ִϸ��̼Ǵ� �� ���ڱ�
        rb.MovePosition(rb.position + 
            movement * animator.deltaPosition.magnitude);
        // rb.MoveRotation : �����ٵ� ���� ȸ��
        rb.MoveRotation(rotation);
    }
}
