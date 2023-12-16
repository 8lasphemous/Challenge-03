using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementStateManager : MonoBehaviour
{
    public float moveSpeed = 3;
    [HideInInspector] public Vector3 dir;
    public float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;
    [SerializeField] LayerMask groundMask;
    Vector3 spherePos;

    [SerializeField] float gravity = -9.18f;
    [SerializeField] float jumpForce = 10;
    [HideInInspector] public bool jumped;
    [HideInInspector] public bool Light;
    [HideInInspector] public bool Heavy;
    Vector3 velocity;

    
    public bool animatorInTransition = false;
    public MovementBaseState previousState;
    public MovementBaseState currentState;

    public IdleState Idle = new IdleState();
    public WalkingState Walking = new WalkingState();
    public DodgeState Dodge = new DodgeState();
    public RunningState Running = new RunningState();

    

    public JumpState Jump = new JumpState();
    public LightState LightMelee = new LightState();
    public HeavyState HeavyMelee = new HeavyState();

    public BowState BowState = new BowState();

    [HideInInspector] public Animator anim;


    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        SwitchState(Idle);

        
    }

    public void Update()
    {
        GetDirectionAndMove();
        Gravity();

        anim.SetFloat("vInput", hzInput);
        anim.SetFloat("hzInput", vInput);

        currentState.UpdateState(this);
    }

    public void SwitchState(MovementBaseState state)
    {

        currentState = state;
        currentState.EnterState(this);
    }


    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");
        
        dir = transform.forward * vInput + transform.right * hzInput;
       
        controller.Move(dir * moveSpeed * Time.deltaTime);
    }

    public bool IsGrounded()
    {
        Vector3 spherePos = new Vector3(transform.position.x, transform.position.y - groundYOffset, transform.position.z);
        if (Physics.CheckSphere(spherePos, controller.radius - 0.05f, groundMask)) return true;
        return false;
    }

    void Gravity()
    {
        if (!IsGrounded()) velocity.y += gravity * Time.deltaTime;
        else if (velocity.y < 0) velocity.y = -2;

        controller.Move(velocity * Time.deltaTime);
    }


    public void JumpForce() => velocity.y += jumpForce;
    public void Jumped() => jumped = true;

    public void ExitLightMelee()
    {
        animatorInTransition = false;
        anim.SetBool("LightMelee", false);
    }

    public void ExitHeavyMelee()
    {
        animatorInTransition = false;
        anim.SetBool("HeavyMelee", false);
    }

    public void ExitBowState()
    {
        animatorInTransition = false;
        anim.SetBool("BowState", false);
    }
}
