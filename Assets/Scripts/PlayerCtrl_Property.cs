using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class PlayerController : MonoBehaviour
{
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }

    public Rigidbody PlayerRigid
    {
        get { return playerRigid; }
    }

    public Vector3 Dir
    {
        get { return dir; }
        set { dir = value; }
    }

    public Vector3 MoveDir
    {
        get { return moveDir; }
        set { moveDir = value; }
    }
}
