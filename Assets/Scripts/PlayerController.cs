using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerController : MonoBehaviour
{
    private Vector2 dir;
    private Vector3 moveDir;
    public Vector2 mouseDelta;

    [SerializeField]
    private Rigidbody playerRigid;

    [SerializeField]
    private Animator playerAnimator;

    [SerializeField]
    private Transform playerTransform;

    [Header("이동 속도")]
    [SerializeField]
    private float moveSpeed = 5.0f;

    [Header("마우스 감도")]
    [SerializeField]
    private float mouseSensitivity = 5f;

    IPlayerState playerCurrentState;

    void Start()
    {
        ChangeState(new IdleState());
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        moveDir = new Vector3(dir.x, 0, dir.y);

        MoveDir = playerTransform.right * MoveDir.x + playerTransform.forward * MoveDir.z;
        moveDir.y = 0;

        playerAnimator.SetFloat("Horizontal", dir.x);
        playerAnimator.SetFloat("Vertical", dir.y);
    }

    public void OnLook(InputAction.CallbackContext ctx)
    {
        mouseDelta = ctx.ReadValue<Vector2>();
    }

    public void ChangeState(IPlayerState newState)
    {
        playerCurrentState = newState;
        playerCurrentState.EnterState(this);
    }

    private void Update()
    {
        playerTransform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivity * Time.deltaTime);

        playerCurrentState.UpdateState(this);

    }

    private void FixedUpdate()
    {
        playerCurrentState.FixedUpdateState(this);
    }

    
}
