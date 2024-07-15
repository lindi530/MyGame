using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerInputSetting playerInputSetting;
    public Vector2 playerMove = Vector2.zero;
    void Awake()
    {
        playerInputSetting = new PlayerInputSetting();
    }
    void Start()    
    {
//Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        playerMove = playerInputSetting.Player.Move.ReadValue<Vector2>().normalized;
    }
    private void OnEnable()
    {
        playerInputSetting.Enable();
    }
    private void OnDisable()
    {
        playerInputSetting.Disable();
    }
}
