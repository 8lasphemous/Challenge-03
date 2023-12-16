using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {

    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.dir.magnitude > 0.1f)
        {
            if (Input.GetKey(KeyCode.LeftShift)) movement.SwitchState(movement.Running);
            else movement.SwitchState(movement.Walking);
        }
        if (Input.GetKeyDown(KeyCode.C)) movement.SwitchState(movement.Dodge);

        

        if (Input.GetKeyDown(KeyCode.H))
        {
            movement.previousState = this;
            movement.SwitchState(movement.HeavyMelee);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            movement.previousState = this;
            movement.SwitchState(movement.Jump);

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            movement.previousState = this;
            movement.SwitchState(movement.LightMelee);

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            movement.previousState = this;
            movement.SwitchState(movement.BowState);

        }
    }
}
