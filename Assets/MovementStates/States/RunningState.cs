using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Running", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftShift)) ExitState(movement, movement.Walking);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.previousState = this;
            ExitState(movement, movement.Jump);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            movement.previousState = this;
            ExitState(movement, movement.HeavyMelee);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            movement.previousState = this;
            ExitState(movement, movement.LightMelee);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            movement.previousState = this;
            ExitState(movement, movement.BowState);
        }
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Running", false);
        movement.SwitchState(state);
    }
}
