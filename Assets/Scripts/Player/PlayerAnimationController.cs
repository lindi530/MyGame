using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerAnimationSymbol
{
    idle = 0,
    run = 1,
    runEndLeft = 2,
    runEndRight = 3,
    turnBack = 4,
}

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private int symbol = -1;

    public void ChangeAnimationSymbol(int symbol)
    {
        this.symbol = symbol;
        PerformAnimation();
    }
    private void PerformAnimation()
    {
        animator.SetInteger("Symbol", symbol);
    }

    private void Update()
    {
        if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") 
           && animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f 
           && !animator.IsInTransition(0)
           )
        {
            ChangeAnimationSymbol((int)PlayerAnimationSymbol.idle);
        }
        
    }  
}

