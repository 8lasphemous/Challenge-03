using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : MovementBaseState
{
    // Start is called before the first frame update
    public override void EnterState(MovementStateManager movement)
    {
        movement.anim.SetBool("Dodge", true);
    }

    // Update is called once per frame
    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKey(KeyCode.LeftShift)) ExitState(movement, movement.Running);
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (movement.dir.magnitude < 0.1f) ExitState(movement, movement.Idle);
            else ExitState(movement, movement.Walking);
        }
    }
    
    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.anim.SetBool("Dodge", false);
        movement.SwitchState(state);
    }
}
