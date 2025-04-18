using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 dir;
    Vector3 moveDir;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMove(InputAction.CallbackContext ctx)
    {
        dir = ctx.ReadValue<Vector2>();
        moveDir = new Vector3(dir.x, 0 ,dir.y);
    }
}
