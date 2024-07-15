using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    [SerializeField] Behaviour[] componentsToDisable;
    [SerializeField] private Animator animator;
    void Start()
    {
        if(!IsLocalPlayer)
        {
            for (int i = 0; i < componentsToDisable.Length; i++)
            {
                if (componentsToDisable[i] != null)
                {
                    componentsToDisable[i].enabled = false;
                }
            }
            animator.applyRootMotion = false;
        }
        
    }
}
