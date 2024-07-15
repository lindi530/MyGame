using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    [HideInInspector] 
    public string playerFoot = "rightFoot";
    
    public void SetPlayerFoot()
    {
        playerFoot = playerFoot == "leftFoot" ? "rightFoot" : "leftFoot";
    }
}
