using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement playerMovement;

    void Update()
    {
        if (playerMovement.state == State.Idle)
        {
            animator.SetInteger("AnimationState", 0);
        }
        else if (playerMovement.state == State.Running)
        {
            animator.SetInteger("AnimationState", 1);

        }
        else if (playerMovement.state == State.Rolling)
        {
            animator.SetInteger("AnimationState", 2);

        }
    }
}
