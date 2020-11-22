using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    private Transform tr = null;
    private Animator animator = null;

    private CharacterController cc = null;

    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;
    public float currMoveSpeed = 10.0f;
    public float currRotateSpeed = 45.0f;

    private Vector3 gravityDir = Vector3.zero;
    public float currGravity = Physics.gravity.y;

    private Vector3 moveDir = Vector3.zero;
    private Quaternion rotateDir = Quaternion.identity;

    public GameObject character = null;
    public GameObject playerCamera = null;

    public int comboNum = 0;
    public bool atkInputEnabled = true;

    private void Start()
    {
        tr = GetComponent<Transform>();
        cc = GetComponent<CharacterController>();
        animator = character.GetComponent<Animator>();
    }

    void Update()
    {
        // 이동입력
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        // 이동방향 계산
        moveDir = (verticalInput * tr.forward)
            + (horizontalInput * tr.right);

        //// 이동입력이 있을 때만 이동방향을 구한다.
        //if (moveDir.sqrMagnitude != 0)
        //{
        //    rotateDir = Quaternion.LookRotation(moveDir);
        //}

        if (Input.GetMouseButtonDown(0) && atkInputEnabled)
        {
            animator.SetInteger("comboNum", comboNum);
            animator.SetTrigger("Attack");
            comboNum = (comboNum == 0) ? 1 : 0;
            atkInputEnabled = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack1") ||
            animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Attack2"))
        {
            Input.ResetInputAxes();
            moveDir = Vector3.zero;
        }

        cc.Move(moveDir.normalized * currMoveSpeed * Time.deltaTime);

        // 이동 애니메이션 출력
        animator.SetFloat("moveInput", moveDir.magnitude);
    }
}
