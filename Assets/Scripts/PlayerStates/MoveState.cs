using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : IPlayerState
{
    public void EnterState(PlayerController player)
    {

    }

    public void UpdateState(PlayerController player)
    {
        if(player.MoveDir == Vector3.zero)
        {
            player.ChangeState(new IdleState());
        }
    }

    public void FixedUpdateState(PlayerController player)
    {
        player.PlayerRigid.MovePosition(player.PlayerRigid.position + 
            player.MoveDir * Time.deltaTime *player.MoveSpeed);
        //player.PlayerRigid.MoveRotation(player.PlayerRigid.rotation * new Vector3(player.mouseDelta.x , 0 , player.mouseDelta.y) * Time.deltaTime)
    }
}
