using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHandGrab : MonoBehaviour
{
    public Animator animator;
    public Transform leftHandTarget; // �ѿ� ���� LeftHandHoldPoint�� �ֱ�

    void OnAnimatorIK(int layerIndex)
    {
        if (animator && leftHandTarget != null)
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
            animator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);

            animator.SetIKPosition(AvatarIKGoal.LeftHand, leftHandTarget.position);
            animator.SetIKRotation(AvatarIKGoal.LeftHand, leftHandTarget.rotation);
        }
    }
}
