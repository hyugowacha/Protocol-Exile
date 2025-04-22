using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerState
{
    public void EnterState(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {
        if(player.MoveDir != Vector3.zero)
        {
            player.ChangeState(new MoveState());
        }
    }

    public void FixedUpdateState(PlayerController player)
    {

    }
}
