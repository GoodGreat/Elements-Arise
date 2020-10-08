using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    const float locomationAnimationSmoothTime = .1f;

    NavMeshAgent agent;
    Animator animator;
    protected CharacterCombat combat;

    /*
    public bool canJump = true;
    public float gravity = 25.0f;
    public float jumpAcceleration = 5.0f;
    public float jumpHeight = 3.0f;
    public float doubleJumpHeight = 4f;

    private float jumping = 0f;
    */
    [HideInInspector] float velocityZ = 0f;
    [HideInInspector] float velocityX = 0f;
    [HideInInspector] public Vector3 currentVelocity;


    public float inAirSpeed = 6f;

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        combat = GetComponent<CharacterCombat>();

        combat.OnAttack += OnAttack;
        combat.OnStrongAttack += OnStrongAttack;
        combat.OnMagicAttack += OnMagicAttack;

        animator.SetBool("Armed", true);
        animator.SetInteger("Weapon", 7);
        animator.SetBool("Shield", false);
        animator.SetTrigger("InstantSwitchTrigger");
        animator.SetInteger("RightWeapon", 9);
        animator.SetInteger("AttackSide", 2);
    }
	
	// Update is called once per frame
	void Update () {
        velocityZ = agent.velocity.magnitude;
     
        if(velocityZ > 0)
        {
            animator.SetBool("Moving", true);
            animator.SetFloat("Velocity Z", velocityZ);
        }
        else
        {
            animator.SetBool("Moving", false);
            animator.SetFloat("Velocity Z", 0);
        }

        animator.SetBool("InCombat", combat.InCombat);

        /*
        jumping = Input.GetAxis("Jump");
        if(jumping > 0)
        {
            Jump_EnterState();
        }
        */

        

    }

    protected virtual void OnAttack()
    {
        //Cambiar por las animaciones con arma correctas
        animator.SetTrigger("Attack8Trigger");
        //animator.SetInteger("Action", 1);
    }

    protected virtual void OnStrongAttack()
    {
        //Cambiar por las animaciones correctas
        animator.SetTrigger("Attack9Trigger");
        //animator.SetInteger("Action", 1);
    }

    protected virtual void OnMagicAttack()
    {
        //Cambiar por las animaciones correctas
        Debug.Log("Animacion de magia por añadir");

    }

    public void DieAnimation()
    {
        animator.SetTrigger("Death1Trigger");
    } 

    /*
    private float CalculateJumpSpeed(float jumpHeight, float gravity)
    {
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    void Jump_EnterState()
    {
        canJump = false;
        velocityX = CalculateJumpSpeed(jumpHeight, gravity);
        animator.SetInteger("Jumping", 1);
        animator.SetTrigger("JumpTrigger");
        animator.SetBool("Moving", true);
        animator.SetFloat("Velocity X", velocityX);
        Fall_EnterState();
    }

    
    void Jump_SuperUpdate()
    {
        Vector3 planarMoveDirection = Math3d.ProjectVectorOnPlane(transform.up, currentVelocity);
        Vector3 verticalMoveDirection = currentVelocity - planarMoveDirection;
        if (Vector3.Angle(verticalMoveDirection, transform.up) > 90)
        {
            currentVelocity = planarMoveDirection;
            return;
        }
        planarMoveDirection = Vector3.MoveTowards(planarMoveDirection, Vector3.zero * inAirSpeed, jumpAcceleration * Time.deltaTime);
        verticalMoveDirection -= transform.up * gravity * Time.deltaTime;
        currentVelocity = planarMoveDirection + verticalMoveDirection;
        if(currentVelocity.y < 0){
            Fall_EnterState();
        }
    }
    

    void Fall_EnterState()
    {
        canJump = false;
        animator.SetInteger("Jumping", 0);
        animator.SetBool("Moving", false);

    }
    */

}
