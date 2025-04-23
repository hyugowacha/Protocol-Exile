using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class PlayerController : MonoBehaviour
{
    private Vector2 dir;
    private Vector3 moveDir;
    private Vector2 lerpDir;

    public Vector2 mouseDelta;
    public float animLerpSpeed = 10.0f;

    private PlayerInput playerInput;
    private InputActionMap mainActionMap;
    private InputAction moveAction;
    private InputAction lookAction;
    private InputAction attackAction;
    private InputAction jumpAction;

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
        playerInput = GetComponent<PlayerInput>();
        mainActionMap = playerInput.actions.FindActionMap("PlayerActions");

        moveAction = mainActionMap.FindAction("Move");
        lookAction = mainActionMap.FindAction("Look");
        jumpAction = mainActionMap.FindAction("Jump");
        attackAction = mainActionMap.FindAction("Attack");

        moveAction.performed += OnMove;
        moveAction.canceled += OnMove;

        lookAction.performed += OnLook;
        lookAction.canceled += OnLook;  

        ChangeState(new IdleState());
    }

    private void AttackAction_started(InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        moveDir = new Vector3(dir.x, 0, dir.y);

        
    }

    public void PlayerMove()
    {
        Vector3 playerForward = playerTransform.TransformDirection(Vector3.forward);
        Vector3 playerRight = playerTransform.TransformDirection(Vector3.right);

        Vector3 desiredMoveDir = playerForward * moveDir.z + playerRight * moveDir.x;

        desiredMoveDir.y = 0;
        desiredMoveDir.Normalize();

        playerRigid.MovePosition(playerRigid.position + desiredMoveDir * Time.deltaTime * moveSpeed);
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
        lerpDir = Vector2.Lerp(lerpDir, dir, Time.deltaTime * animLerpSpeed);

        playerAnimator.SetFloat("Horizontal", lerpDir.x);
        playerAnimator.SetFloat("Vertical", lerpDir.y);

        playerCurrentState.FixedUpdateState(this);
    }

    
}
