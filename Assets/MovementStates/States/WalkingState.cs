using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Walking", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Running);
        else if (Input.GetKeyDown(KeyCode.C)) ExitState(movement, movement.Dodge);
        else if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.previousState = this;
            ExitState(movement, movement.Jump);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            movement.previousState = this;
            ExitState(movement, movement.Jump);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            movement.previousState = this;
            ExitState(movement, movement.Jump);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            movement.previousState = this;
            ExitState(movement, movement.BowState);
        }
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Walking", false);
        movement.SwitchState(state);
    }
}
