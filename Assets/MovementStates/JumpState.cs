using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        if (movement.previousState == movement.Idle) movement.anim.SetTrigger("IdleJump");
        else if (movement.previousState == movement.Walking || movement.previousState == movement.Running) movement.anim.SetTrigger("RunningJump");
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if(movement.jumped && movement.IsGrounded())
        {
            movement.jumped = false;
            if (movement.hzInput == 0 && movement.vInput == 0) movement.SwitchState(movement.Idle);
            else if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Running);
            else movement.SwitchState(movement.Walking);
        }
    }
}
