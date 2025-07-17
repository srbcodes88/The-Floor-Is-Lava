using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Play : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float rotationSpeed = 1f;
    public float jumpForce = 7f;
    CharacterController characterController;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        bool ForwardRunning = animator.GetBool("IsForwardRunning");
        bool BackwardRunning = animator.GetBool("IsBackwardRunning");
        bool RunJumping = animator.GetBool("IsRunJumping");
        bool StandJumping = animator.GetBool("IsStandJumping");
        bool Jump = Input.GetKeyDown("space");
        bool Forward = Input.GetKey("w");
        bool Backward = Input.GetKey("s");
        if (!ForwardRunning && Forward)
        {
            animator.SetBool("IsForwardRunning", true);
        }

        if (ForwardRunning && !Forward)
        {
            animator.SetBool("IsForwardRunning", false);
        }

        if (ForwardRunning && !RunJumping && Jump)
        {
            animator.SetBool("IsRunJumping", true);
        }

        if (RunJumping && ForwardRunning || Forward && RunJumping || RunJumping && !ForwardRunning)
        {
            animator.SetBool("IsRunJumping", false);
        }

        if (!ForwardRunning && Jump)
        {
            animator.SetBool("IsStandJumping", true);
        }

        if (StandJumping && !Jump)
        {
            animator.SetBool("IsStandJumping", false);
        }

        if (StandJumping && !Jump && Forward)
        {
            animator.SetBool("IsStandJumping", false);
            animator.SetBool("IsForwardRunning", true);
        }

        if (!BackwardRunning && Backward)
        {
            animator.SetBool("IsBackwardRunning", true);
        }

        if (BackwardRunning && !Backward)
        {
            animator.SetBool("IsBackwardRunning", false);
        }

        if (BackwardRunning && !RunJumping && Jump)
        {
            animator.SetBool("IsRunJumping", true);
        }

        if (RunJumping && BackwardRunning || Backward && RunJumping || RunJumping && !BackwardRunning)
        {
            animator.SetBool("IsRunJumping", false);
        }

        if (!BackwardRunning && Jump)
        {
            animator.SetBool("IsStandJumping", true);
        }

        if (StandJumping && !Jump && Backward)
        {
            animator.SetBool("IsStandJumping", false);
            animator.SetBool("IsBackwardRunning", true);
        }
    }


}