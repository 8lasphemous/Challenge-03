using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.animatorInTransition = true;

    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyDown(KeyCode.B))
        {

            movement.anim.SetBool("BowState", true);

            if (movement.dir.magnitude < 0.1f)
            {
                if (!movement.animatorInTransition) movement.SwitchState(movement.Idle);
            }
            else
            {
                if (!movement.animatorInTransition) movement.SwitchState(movement.Walking);
            }
        }
        ExitState(movement);
    }

    void ExitState(MovementStateManager movement)
    {
        movement.animatorInTransition = false;

    }
}
